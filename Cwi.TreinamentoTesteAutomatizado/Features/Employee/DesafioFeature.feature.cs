// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace Cwi.TreinamentoTesteAutomatizado.Features.Employee
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Desafio")]
    public partial class DesafioFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
#line 1 "DesafioFeature.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("pt-BR"), "Features/Employee", "Desafio", null, ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("DESAFIO 1 - Criação de funcionários com sucesso e validação da listagem dos mesmo" +
            "")]
        public void DESAFIO1_CriacaoDeFuncionariosComSucessoEValidacaoDaListagemDosMesmo()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DESAFIO 1 - Criação de funcionários com sucesso e validação da listagem dos mesmo" +
                    "", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 3
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 4
 testRunner.Given("que a base de dados esteja limpa", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line hidden
                TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "Name",
                            "Email",
                            "Active"});
                table4.AddRow(new string[] {
                            "1",
                            "\'TesteDB\'",
                            "\'db@teste.com\'",
                            "true"});
#line 5
 testRunner.And("que o funcionário seja inserido na tabela \'Employee\' do DB", ((string)(null)), table4, "E ");
#line hidden
#line 16
 testRunner.Then("com o usuário autenticado, seja feita uma chamado do tipo \'GET\' para o endpoint \'" +
                        "v1/employees\', seu retorno será", "[{\"id\":1,\"name\":\"TesteDB\",\"email\":\"db@teste.com\",\"active\":true}]", ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("DESAFIO 2 - Exclusão de funcionário com sucesso")]
        public void DESAFIO2_ExclusaoDeFuncionarioComSucesso()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DESAFIO 2 - Exclusão de funcionário com sucesso", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 24
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 25
 testRunner.Given("que o usuário esteja autenticado", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line hidden
                TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                            "Name",
                            "Email"});
                table5.AddRow(new string[] {
                            "Teste Exclusão",
                            "email@exclusao.com"});
#line 26
 testRunner.And("que seja solicitado a criação de um novo funcionário", ((string)(null)), table5, "E ");
#line hidden
#line 29
 testRunner.And("que o usuário esteja autenticado", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
#line 30
 testRunner.Then("seja feita uma chamada com o método \'DELETE\' para o endpoint \'v1/employees/1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
#line 31
 testRunner.And("o código de retorno será \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("DESAFIO FEITEIRO - Inserção e deleção de funcionário via DB")]
        public void DESAFIOFEITEIRO_InsercaoEDelecaoDeFuncionarioViaDB()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("DESAFIO FEITEIRO - Inserção e deleção de funcionário via DB", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 41
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 42
 testRunner.Given("que a base de dados esteja limpa", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Dado ");
#line hidden
                TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "Name",
                            "Email",
                            "Active"});
                table6.AddRow(new string[] {
                            "1",
                            "\'TesteDB\'",
                            "\'db@teste.com\'",
                            "true"});
#line 43
 testRunner.And("que o funcionário seja inserido na tabela \'Employee\' do DB", ((string)(null)), table6, "E ");
#line hidden
#line 47
 testRunner.And("que o usuário esteja autenticado", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
#line 48
 testRunner.Then("seja feita uma chamada com o método \'DELETE\' para o endpoint \'v1/employees/1\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Então ");
#line hidden
#line 50
 testRunner.And("o código de retorno será \'200\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "E ");
#line hidden
                TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                            "Id",
                            "Name",
                            "Email",
                            "Active"});
                table7.AddRow(new string[] {
                            "1",
                            "\'TesteDB\'",
                            "\'db@teste.com\'",
                            "true"});
#line 51
 testRunner.And("não haverá mais o registro com na tabela \'Employee\' do DB", ((string)(null)), table7, "E ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
