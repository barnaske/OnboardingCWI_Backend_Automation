Funcionalidade: CadastroDeFuncionariosFeature
	Sendo um usuário com as devidas permissões
	Quero poder cadastrar um novo funcionário

@Employee @CreateEmployee
Cenário: Cadastro de funcionário sem autenticação
	Dado que o usuário não esteja autenticado
	E que seja solicitado a criação de um novo funcionário
	Então o funcionário não será cadastrado
	E serã retornado uma mensagem de falha de autenticação

@Employee @CreateEmployee
Cenário: Cadastro de funcionário com sucesso
	Dado que o usuário esteja autenticado
	E que seja solicitado a criação de um novo funcionário
	Então o funcionário será cadastrado
