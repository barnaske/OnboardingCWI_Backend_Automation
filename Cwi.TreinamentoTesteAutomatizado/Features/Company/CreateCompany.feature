Funcionalidade: Criar empresa

Cenário: Criação de empresa com sucesso
	Dado que a base de dados esteja limpa
	E que o usuário esteja autenticado
	E seja feita uma chamado do tipo 'POST' para o endpoint 'v1/companies' com o corpo da requisição
	"""
		{
		  "name": "<Name>",
		  "code": "<Code>",
		  "maxEmployeesNumber": 5
		}
	"""
	Então o código de retorno será '201'
	E o registro estará disponível na tabela 'Company' da base de dados
	| Id | Name     | Code     | MaxEmployeesNumber | Active |
	| 1  | '<Name>' | '<Code>' | 5                  | true   |

Exemplos:
	| Name      | Code |
	| Empresa 1 | 001  | 