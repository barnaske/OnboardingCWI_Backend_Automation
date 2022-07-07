Funcionalidade: Obter Empresas
	Simple calculator for adding two numbers

@Companies
Cenário: Obter empresas com a base limpa 
	Dado que a base de dados esteja limpa
	E que o usuário esteja autenticado 
	Quando seja realizada um requisição com o método 'GET' para o endpoint 'v1/companies'     
	Então o código de retorno será '204'
	