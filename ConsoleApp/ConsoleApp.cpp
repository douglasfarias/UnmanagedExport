#include <iostream>
#include <Windows.h>

struct Foo
{
	std::string Value;
};

typedef void (*AddFooFunc)(Foo* value);

int main() {
	auto hModule = LoadLibrary(L"ClassLibrary.dll");
	if (hModule == NULL) {
		std::cerr << "Erro ao carregar a DLL." << std::endl;
		return 1;
	}

	auto addFoo = (AddFooFunc)GetProcAddress(hModule, "AddFoo");
	if (addFoo == NULL) {
		std::cerr << "Erro ao obter o endereço da função AddFoo." << std::endl;
		return 1;
	}

	Foo value = { "foobar" };

	addFoo(&value);

	std::cout << "AddFoo executada com sucesso!" << std::endl;

	FreeLibrary(hModule);

	system("pause");

	return 0;
}
