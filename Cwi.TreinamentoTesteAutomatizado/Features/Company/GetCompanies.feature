Funcionalidade: Obter Empresas
	Simple calculator for adding two numbers

@Companies
Cenário: Obter empresas com a base limpa 
	Dado a base de dados esteja limpa
	E o usuário esteja autenticado
	Quando for realizada um requisição com o método 'GET' para o endpoint 'v1/companies'     
	Então o código de retorno será '204'
	