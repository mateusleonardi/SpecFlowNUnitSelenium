Primeiros passos com SpecFlow:
http://www.specflow.org/guidance/first-steps/

###########################################################

Caso você adicione features ou testes e não apareça para execução, siga os seguintes passos:
* Saia do Visual Studio
* Abra o Windows Explorer
* Na barra de endereços, informe %TEMP% e tecle Enter.
* Procure arquivos que comecem com "specflow" com extensão .cache
* Delete todos esses arquivos
* Abra seu projeto no Visual Studio novamente

###########################################################

###########################################################

Para rodar com sucesso seus testes, vá no arquivo SeleniumHelper.cs e coloque na linha 71 o endereço correto do seu ChromeDriver.
(Será corrigido o quanto antes)

###########################################################


Se desejarem se tornar colaboradores, só falar.

Observação:
Foi um projeto feito de maneira rápida para mostrar o funcionamento básico do SpecFlow + NUnit + Selenium.
Qualquer sugestão, por gentileza compartilhe, será um prazer contribuir de acordo com sua necessidade.

Obrigado.