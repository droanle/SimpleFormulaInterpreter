# SimpleFormulaInterpreter

O **SimpleFormulaInterpreter** é um programa desenvolvido para interpretar fórmulas utilizadas em fichas de personagens de RPG de mesa.

Em muitos sistemas de RPG, as fichas contêm **Atributos**, **Perícias**, **Qualidades/Defeitos** e outros elementos que definem as capacidades e limitações dos personagens. Além disso, existem os chamados **Atributos Secundários** (como Pontos de Vida, Pontos de Magia, etc.), que normalmente são derivados de outras propriedades da ficha por meio de fórmulas.

Este interpretador foi criado para processar automaticamente essas fórmulas, bastando fornecer os valores da ficha (através da classe `data`) e a fórmula correspondente.

> ⚠️ Este projeto também foi criado com o propósito de estudo de algoritmos recursivos. O processamento de operações dentro de parênteses é feito por recursão.

---

## Exemplo

```plaintext
Pontos de Vida = ((força + constituição) * 4) + 10
```

No exemplo acima, `força` e `constituição` são atributos definidos na ficha. A fórmula é simples, mas o sistema permite expressões muito mais complexas.

---

## Sintaxe Suportada

### Variáveis

As variáveis são identificadas por chaves `{}`.

```plaintext
{FOR}
```

No exemplo acima, o valor da variável `FOR` será buscado nos dados da ficha.

---

### Rolagem de Dados

Para simular a rolagem de dados, utilize `:D` seguido do número de lados do dado.

```plaintext
:D20
```

Isso representa a rolagem de um dado de 20 lados.

---

### Agrupamento de Expressões

Use parênteses `()` para agrupar operações e controlar a ordem de execução:

```plaintext
((força + constituição) * 4) + 10
```

---

## Operadores Suportados

### Aritméticos

| Símbolo | Operação      |
| ------- | ------------- |
| `+`     | Soma          |
| `_`     | Subtração     |
| `*`     | Multiplicação |
| `/`     | Divisão       |

### Comparações

| Símbolo | Operação  |
| ------- | --------- |
| `=`     | Igualdade |
| `!`     | Diferença |
| `>`     | Maior que |
| `<`     | Menor que |

---

## Estruturas Condicionais

A estrutura condicional segue o formato:

```plaintext
[condição?valor_se_verdadeiro;valor_se_falso]
```

* A condição deve ser `true` ou `false`.
* Os resultados são separados por ponto e vírgula `;`.

### Exemplos

```plaintext
[true?150;698]    → retorna 150
[false?652;987]   → retorna 987
```

> ℹ️ Esta estrutura foi inspirada no operador ternário comum em linguagens de programação.

---

## Conclusão

O **SimpleFormulaInterpreter** é uma ferramenta e flexível criada para automatizar cálculos em fichas de RPG, suportando variáveis, rolagens de dados, operadores matemáticos e condicionais. Ele também serve como base de estudo para algoritmos recursivos e processamento de expressões.

Ideal para mestres de RPG que desejam facilitar sua mesa ou desenvolvedores interessados em lógica de interpretação de fórmulas.
