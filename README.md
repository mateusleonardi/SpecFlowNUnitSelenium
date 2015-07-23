# Primeiros passos com SpecFlow:
http://www.specflow.org/guidance/first-steps/


# Como corrigir corrigir possíveis erros

## Novas Features não aparecem para serem executadas

Caso você adicione features ou testes e não apareça para execução, siga os seguintes passos:
* Saia do Visual Studio
* Abra o Windows Explorer
* Na barra de endereços, informe %TEMP% e tecle Enter.
* Procure arquivos que comecem com "specflow" com extensão .cache
* Delete todos esses arquivos
* Abra seu projeto no Visual Studio novamente

## ReSharper
Caso você esteja usando ReSharper, desabilite a opção "Shadow-copy assemblies being tested" indo em:
Menu RESHARPER >> Options >> Tools >> Unit Testing

Se desejarem se tornar colaboradores, só falar.

### Observação:
Foi um projeto feito de maneira rápida para mostrar o funcionamento básico do SpecFlow + NUnit + Selenium.
Qualquer sugestão, por gentileza compartilhe, será um prazer contribuir de acordo com sua necessidade.