Funcionalidade: Criar funcionários com steps genéricos
	Sendo um usuário com as devidas permissões
	Quero poder cadastrar um novo funcionário

Cenário: Criação de funcionário com sucesso
	Dado que a base de dados esteja limpa
	E que o usuário esteja autenticado
	E seja feita uma chamado do tipo 'POST' para o endpoint 'v1/employees' com o corpo da requisição
	"""
		{
		  "name": "<Name>",
		  "email": "funcionario1@empresa.com"
		}
	"""
	Então o código de retorno será '201'
	E o registro estará disponível na tabela 'Employee' da base de dados
	| Id | Name     | Email                      | Active |
	| 1  | '<Name>' | 'funcionario1@empresa.com' | true   |

Exemplos:
	| Name          |
	| Funcionário 1 |