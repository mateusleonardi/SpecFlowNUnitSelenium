#language: pt-br
Funcionalidade: My First NUnit Test
	Para que possamos fazer nosso primeiro NUnit Test
	Como um developer
	Eu preciso garantir que os métodos de pré e pós testes estejam funcionando

Cenário: Rodar um NUnit de exemplo com sucesso
Dado que eu esteja fazendo meu primeiro NUnit
E desejo validar se o parâmetro "NUnit is awesome" está sendo passado com sucesso
Quando confirmo que o parâmetro foi guardado em uma variável
Então o resultado é positivo

Cenário: Rodar um NUnit de exemplo sem sucesso
Dado que eu esteja fazendo meu primeiro NUnit
E desejo validar se o parâmetro "NUnit is awesome yet" está sendo passado com sucesso
Quando confirmo que o parâmetro foi guardado em uma variável
Então o resultado é negativo