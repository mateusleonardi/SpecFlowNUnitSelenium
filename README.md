Primeiros passos com SpecFlow:
http://www.specflow.org/guidance/first-steps/

Caso você adicione features ou testes e não apareça para execução, siga os seguintes passos:
* Saia do Visual Studio
* Abra o Windows Explorer
* Na barra de endereços, informe %TEMP% e tecle Enter.
* Procure arquivos que comecem com "specflow" com extensão .cache
* Delete todos esses arquivos
* Abra seu projeto no Visual Studio novamente