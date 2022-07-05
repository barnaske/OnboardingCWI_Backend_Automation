Funcionalidade: Desafio

Cenário: DESAFIO usando EXEMPLOS - Criação de funcionários com sucesso e validação da listagem dos mesmo
	Dado que a base de dados esteja limpa
	E que o usuário esteja autenticado
	E seja feita uma chamado do tipo 'POST' para o endpoint 'v1/employees' com o corpo da requisição
	"""
		{
		  "name": "<Name>",
		  "email": "<Email>"
		}
	"""
	Então o código de retorno será '201'
	E com o usuário autenticado, seja feita uma chamado do tipo 'GET' para o endpoint 'v1/employees', seu retorno será
	"""
	[{"id":1,"name":"Funcionário 1","email":"funcionario1@empresa.com","active":true}]
	"""

Exemplos:
	| Name          | Email                    |
	| Funcionário 1 | funcionario1@empresa.com |