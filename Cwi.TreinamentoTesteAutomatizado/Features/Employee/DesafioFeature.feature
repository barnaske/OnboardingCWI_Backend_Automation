Funcionalidade: Desafio

Cenário: DESAFIO 1 - Criação de funcionários com sucesso e validação da listagem dos mesmo
	Dado que a base de dados esteja limpa
	E que o funcionário seja inserido na tabela 'Employee' do DB 
	#está em DatabaseSteps
	| Id | Name      | Email          | Active |
	| 1  | 'TesteDB' | 'db@teste.com' | true   |
	#E seja feita uma chamado do tipo 'POST' para o endpoint 'v1/employees' com o corpo da requisição
	#"""
	#	{
	#	  "name": "<Name>",
	#	  "email": "<Email>"
	#	}
	#"""
	Então com o usuário autenticado, seja feita uma chamado do tipo 'GET' para o endpoint 'v1/employees', seu retorno será
	"""
	[{"id":1,"name":"TesteDB","email":"db@teste.com","active":true}]
	"""
	#implementação já ajustada
	#E os registros foram inseridos na base de dados #
	# o teste sempre deve buscar ser independente, nesse caso estou usando dois endpoints para esse teste, logo não é lógico

Cenário: DESAFIO 2 - Exclusão de funcionário com sucesso
	Dado que o usuário esteja autenticado
	E que seja solicitado a criação de um novo funcionário
	| Name           | Email              |
	| Teste Exclusão | email@exclusao.com |
	E que o usuário esteja autenticado
	Então seja feita uma chamada com o método 'DELETE' para o endpoint 'v1/employees/1'
	E o código de retorno será '200'


#DESAFIO FEITEIRO
#Inserir dados pelo banco de dados e validar por ele
#criar novos steps para fazer a inserção e validação, usar DADO e E para instanciar os dados e no ENTÃO fazer a checagem se o
#código de retorno está correto e se os registros não estão mais no banco

#ajustar o desafio 1 para buscar os dados no banco de dados e não usando o get

Cenário: DESAFIO FEITEIRO - Inserção e deleção de funcionário via DB
	Dado que a base de dados esteja limpa
	E que o funcionário seja inserido na tabela 'Employee' do DB 
	#está em DatabaseSteps
	| Id | Name      | Email          | Active |
	| 1  | 'TesteDB' | 'db@teste.com' | true   |
	E que o usuário esteja autenticado
	Então seja feita uma chamada com o método 'DELETE' para o endpoint 'v1/employees/1'
	#está em HttpRequestSteps
	E o código de retorno será '200'
	E não haverá mais o registro com na tabela 'Employee' do DB
	| Id | Name      | Email          | Active |
	| 1  | 'TesteDB' | 'db@teste.com' | true   |
	#está em DatabaseSteps