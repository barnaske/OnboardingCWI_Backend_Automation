Funcionalidade: Cadastro De Funcionarios Feature
	Sendo um usuário com as devidas permissões
	Quero poder cadastrar um novo funcionário

@Employee @CreateEmployee
Cenário: Cadastro de funcionário sem autenticação
	Dado que o usuário não esteja autenticado
	E que seja solicitado a criação de um novo funcionário
	Então o funcionário não será cadastrado
	E será retornado uma mensagem de falha de autenticação

@Employee @CreateEmployee
Cenário: Cadastro de funcionário sem preencher campo obrigatório
	Dado que a base de dados esteja limpa
	E que o usuário esteja autenticado
	E que seja solicitado a criação de um novo funcionário sem o preenchimento dos campos obrigatórios
	Então o funcionário não será cadastrado
	E será retornado uma mensagem de falha de preenchimento de campos obrigatórios

#@Employee @CreateEmployee
#Cenário: Cadastro de funcionário ultrapassando limites de caracteres
#	Dado que a base de dados esteja limpa
#	E que o usuário esteja autenticado
#	E que seja solicitado a criação de um novo funcionário com os campos ultrapassando o limite de caracteres
#	Então o funcionário não será cadastrado
#	E será retornado uma mensagem de falha de preenchimento de campos obrigatórios


@Employee @CreateEmployee
Cenário: Cadastro de funcionário com sucesso
	Dado que a base de dados esteja limpa
	E que o usuário esteja autenticado
	E que seja solicitado a criação de um novo funcionário
	Então o funcionário será cadastrado
	E o registro estará disponível na tabela 'Employee' da base de dados
	| Id | Name            | Email                      | Active | 
	| 1  | 'Funcionario 1' | 'funcionario1@empresa.com' | true   | 

	#A primeira linha da tabela trata-se de um WHERE, que transformaremos na seguinte cláusula
	#= WHERE (Id = 1 AND Name = 'Funcionário 1' AND ...) OR
	#Caso exista uma segunda linha, ela será gerada como
	#= (Id = 2 AND ...) OR
	#Assim seguinte uma query para validar mais de um funcionário registrado
