# SimpleFormulaInterpreter

Este programa foi desenvolvido pensando nas funcionalidades de uma filha de RPG de mesa. Para jogar RPG é necessário que cada jogador crie uma ficha, essa ficha descrever todas as características e capacidades de um personagem, uma ficha normalmente é composta por “Atributos”, "Perícias" e/ou “Defeitos/Qualidades” (a presença destes propriedades e o nome deles pode mudar de acordo com o sistema de RPG em que você estiver jogando, não é uma regra usar esta nomenclatura e organização porém é fácil encontrar sistemas que usam desta mesma organização), estas propriedades definem as habilidades e limitações do seu personagem.

Outras propriedades que uma ficha de RPG tem que ter, são os “Atributos Secundários” (AS), como PV(pontos de vida), PM(pontos de magia) entre outros, estes AS normalmente são derivados das ou outras propriedades da ficha, tendo uma fórmula para cada AS que usa os valores da ficha como variáveis.

- Exemplo:
  > Pontos de vida = ((força + constituição)*4)+10

No exemplo acima **“força”** e **“constituição”** seriam atributos definidos na ficha, vale ressaltar que neste exemplo a fórmula é simples mas em alguns sistemas ela pode ser complexa.

Dado o contexto resolvi escrever este algoritmo, que é feito para resolver este tipo de problema exigindo somente o acesso aos calores da ficha (a classe “data”) e a fórmula que deve ser resolvida seguindo os padrões detalhados abaixo.

``
OBS.: Este programa também foi desenvolvido para fins de estudo sobre algoritmos recursivos. O método que ele usa para dividir as operações nas parentes vem da recursividade
``


### Identificar variável: 
Caractere **“ { ”** seguido do nome da variável, terminado com o caracter **“ } “**. Exemplo de identificação de uma variável com o nome **“ FOR ”**: **{FOR}**
Rolagem de dado:
Se o nome for identificado com os caracteres  **“ :D ”** seguido de um número, significa que ele é uma rolagem de dado. 
- Exemplo:
  > Dizer **“ :D20 “** é o mesmo que rolar um dado de 20 lados.

### Separador: 
O caráter que define uma separação é as parenteses (**“ () ”**).
### Processamento primitivo:
   - **Operadores:**
		- **“ = ”**  = igualdade
        - **“ ! ”**   = desigualdade
        - **“ > ”**  = maior
        - **“ < ”**  = menor
        - **“ * ”**   = multiplicação
        - **“ / ”**   = divisão
        - **“ + ”**  = soma
        - **“ _ ”**   = subtração

   - **Estrutura lógica:**
	    A operação é isolada por um abre e fecha de colchetes (“ [] ”), ela começa com um valor verdadeiro (“ true ”) ou falso (“ false ”) seguido de carácter “ ? ”, as possibilidades dos eventos vem depois sendo separados pelo carácter “ ; ”.
     - Exemplos:
		  > [true?150;698] = 150
    
       > [false?652;987] = 987 
		
      ``OBS: Esta estrutura foi inspirada no operador ternária.``

### Ciclo de processamento:
Primeiro o código altera as **_variáveis_** pelos seus respectivos valores, sem mais nenhuma valor a ser posto na fórmula o programa começa a realizar o trabalho de recursividade dividindo os processo em processos menores usando o **_separador_**, por fim, esses processos menores usam as definições de e estruturas do **_processamento primitivor_** para retornar o valor correto.
