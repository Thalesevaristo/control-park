# DIO - Trilha .NET - Fundamentos

[dio.me](dio.me)

## Desafio de projeto

Aplicando os conhecimentos adquiridos no módulo de fundamentos, da trilha .NET da DIO.

## Contexto

Você foi contratado para construir um sistema para um estacionamento, que será usado para gerenciar os veículos estacionados e realizar suas operações, como por exemplo adicionar um veículo, remover um veículo (e exibir o valor cobrado durante o período) e listar os veículos.

## Proposta

O projeto foi implementado seguindo o modelo proposto.

![Diagrama de classe estacionamento](diagrama_classe_estacionamento.png)

### A classe contém três variáveis, sendo

- **precoInicial**: Tipo decimal. É o preço cobrado para deixar seu veículo estacionado.
- **precoPorHora**: Tipo decimal. É o preço por hora que o veículo permanecer estacionado.
- **veiculos**: É uma lista de string, representando uma coleção de veículos estacionados. Contém apenas a placa do veículo.

### A classe contém três métodos, sendo

- **AdicionarVeiculo**: Método responsável por receber uma placa digitada pelo usuário e guardar na variável **veiculos**.
- **RemoverVeiculo**: Método responsável por verificar se um determinado veículo está estacionado, e caso positivo, irá pedir a quantidade de horas que ele permaneceu no estacionamento. Após isso, realiza o seguinte cálculo: **precoInicial** * **precoPorHora**, exibindo para o usuário.
- **ListarVeiculos**: Lista todos os veículos presentes atualmente no estacionamento. Caso não haja nenhum, exibir a mensagem "Não há veículos estacionados".

### Por último, deverá ser feito um menu interativo com as seguintes ações implementadas

1. Cadastrar veículo
2. Remover veículo
3. Listar veículos
4. Encerrar

---

## Solução

### 1. Lógica de Adicionar e Remover Veículos

Para garantir que a entrada de placas seja consistente e válida, foram criados **dois métodos privados auxiliares**:

- **`FormatarPlaca`**
  Remove espaços e símbolos, deixando apenas letras e números na placa. Isso facilita a validação e o tratamento posterior.
  [Saiba mais sobre regex no C#](https://learn.microsoft.com/pt-br/dotnet/standard/base-types/regular-expressions)

- **`VerificarPlaca`**
  Valida o formato da placa utilizando expressões regulares (regex), conforme os padrões brasileiros do Mercosul (por exemplo: ABC1234 ou ABC1D23).
  [Formato de Placas Brasileiras](https://pt.wikipedia.org/wiki/Placas_de_identifica%C3%A7%C3%A3o_de_ve%C3%ADculos_no_Mercosul)

---

#### Visão Geral

Esses métodos tornam o fluxo do sistema mais seguro e eficiente:

- **`FormatarPlaca`** → padroniza a entrada
- **`VerificarPlaca`** → valida o padrão da placa

---

### Adicionar Veículo

O método `AdicionarVeiculo` utiliza um **loop** para solicitar a placa ao usuário. Durante esse processo, acontecem duas verificações:

- Se a placa já existe na lista de veículos estacionados
- Se a placa está no formato válido

  - **Caso o veículo já esteja estacionado**, uma mensagem de aviso é exibida, e o loop termina.
  - **Caso a placa seja válida e não duplicada**, o veículo é adicionado à lista e o loop se encerra.

---

### Remover Veículo

O método `RemoverVeiculo` também conta com um **loop** para obter a placa a ser removida. O fluxo é o seguinte:

1. A placa informada passa primeiro por `FormatarPlaca`, removendo símbolos desnecessários
2. O sistema verifica se a placa consta na lista de veículos

- **Se encontrado**, o usuário informa o total de horas estacionadas, e o sistema calcula o valor a ser pago
- **Se não encontrado**, uma mensagem de erro aparece, finalizando o processo

---

### Listar Veículos

Para exibir os veículos estacionados, o método `ListarVeiculos` usa um **`foreach`** que percorre todos os itens da lista. As placas são concatenadas em uma única string, que depois é impressa no console.

> Observação: Essa abordagem é mais eficiente do que imprimir veículo por veículo.

---

### 2. Menu Interativo

O menu já existia, mas recebeu melhorias:

- Agora é possível navegar usando as teclas <kbd>↑</kbd> e <kbd>↓</kbd>
- Continua funcionando a entrada por número digitado
- Foram feitos ajustes estéticos, alterando algumas cores

Para implementar essas mudanças, serviram de base:

- [Youtube - How To Create a Interactive Menu in Console App Using C#](https://www.youtube.com/watch?v=YyD1MRJY0qI)
- [Microsoft - ConsoleKey Enum](https://learn.microsoft.com/en-us/dotnet/api/system.consolekey?view=net-9.0)
- [Learning ANSI Escape Codes](https://j8ahmed.com/2021/09/13/day-37-learning-ansi-escape-codes/)

---
