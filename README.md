# Sistema para Reservas de Salas

O trabalho visa construir um sistema para reservas de salas, com limitação de hora mínima e máxima pelo usuário. O programa armazena dados para data, hora, descrição da sala e capacidade (com limite de alunos entre 0 à 40 alunos).

## 📋 Pré-requisitos

Programas usados foram:
- Visual Studio Code: https://code.visualstudio.com
- SDK do .NET x64: https://dotnet.microsoft.com/pt-br/download
- Extensões básicas para C#

## 🔧 Instalação

Baixe ou clone o repositório, contendo todas as pastas, principalmente o Programa.cs e a pasta modelos;
Em uma IDE, abra o código e compile;
Ao rodar a aplicação, mensagens de validação começaram a aparecer.

## ⚙️ Executando os testes

O sistema funciona ao criar instâncias no Programa.cs, utilizando classes do ConfiguracaoReserva.cs e Reserva.cs. 

## 🔩 Validações principais

As validações aplicadas são:

- A data máxima e mínima e a hora máxima e mínima, devem ser definidas pelo usuário, o máximo não pode ser menor que a mínima tanto para data como para hora.
- A data e hora da reserva deve ser dentro do limite que o usuário colocou. 
- A descrição da sala não deve ser nula/ vazia.
- A quantidade de alunos devem ser de 0 à 40 alunos.
- Mensagem de erro são dadas após inserir cada dado respectivamente.

## ⌨️ Estilo de codificação

O projeto segue boas práticas básicas da programação orientada a objeto (00). Fazendo encapsulamento, divisão de responsabilidades, validação e abstração dos dados.

## ✒️ Autores

-Gustavo Finkler Hass
-Pablo Emanuel Cechim de Lima
Tawan Vitor Silva de Oliveira
