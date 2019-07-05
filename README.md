# ClinicaVeterinaraAspNetCore-MVC APLICATIVO VOLTADO A CLINICA VETERINARIA

-Projeto produzido pelo aluno: Lucas Horn Daniel na diciplina de Programação Orientada a Objetos no ano de 2019 - 1º Semestre do Curso de Ciência da Computação, da Universidade Tecnológica Federal do Paraná - UTFPR Medianeira e sob a orientação do professor Everton Coimbra de Araújo.

-O aplicativo foi desenvolvido em C# utilizando o Visual Studio Community 2017 (versão 15.9). Para o Banco foi usado MySql Workbench 8.0 CE (versão 8.0.16) através do Entity framework Core(2.2.4) Usando o MySql Workbench.

# Instalação do Visual Studio Community

-Acesse https://visualstudio.microsoft.com/pt-br/vs/community/, selecione a plataforma utilizada (Windows ou MacOS) e clique em "Baixar o visual Studio escolha a versão 2017.
-Instale normalmente, conforme as instruções que seguirem.

# Intalaçao da aplicação

-Acesso o Link: https://github.com/LucasHornDaniel/ClinicaVeterinaraAspNetCore-MVC
-Clique em "Clone or download" e "Download ZIP";
-Descompacte o arquivo baixado e abra a pasta;
-O arquivo principal é o ClinicaVeterinaria.sln

# Conteudo do Repository

-Controllers: Aonde faz a interação com a Views do projeto como Index, Pesquisa Create, e Delete.

-Data: Essa pasta é aonde é feita a relação das classes com o Banco Data (DbSet) aonde esta todas as classes, para que o Entity Framework conseguida fazer o mapeamento no banco de dados, aqui temos tambem o seeding service um serviço de semeadura que serve para introduzir infromarções no banco.

-Migration: Aonde são feita as migrações para o Banco de dados.

-Models: Contém as classes base utilizadas, desenvolvidas utilizando o padrão do Entity Framework Core (Com os ID's de cada uma das classes e as Foreign Key), Contém tambem a ViewModels das classes, para usar a coleções de outras classes, para que usa-se como forma de List.

-Service: Aonde faz a ligação com os controladores no banco de dados, services->controladores->views. Resumindo ela faz a ligação com o banco de dados MySql Workbench que através dos controladores apresentam a views ao usuário.

-Views: Aonde fica as views para o usuário Idex, Create, Edit, Details atraves de todos os atributos da classes.

ClinicaVeterinaria.sln: Solução da aplicação, usada para gerenciar dos projetos e de todas as views, controladores, services etc...

# OBSERVAÇÃO IMPORTANTE: 
-Não foram feitos testes desse aplicativo em ambientes de trabalho, assim não havendo nenhuma garantia que funcione corretamente.


# Duvidas ou Sujestões:
NOME: LUCAS HORN DANIEL.
EMAIL: lucasdaniel@alunos.utfpr.edu.br








