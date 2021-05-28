# controle-matriculas (DESAFIO)
  Você deve desenvolver um aplicativo (em C# ou Java) que calcule o dígito verificador para uma série de matrículas da empresa XPTO.
  
  Data uma matrícula 0000 a 9999 o cálculo do dígito verificador deverá ser feito multiplicando o primeiro número à esquerda por 5, o segundo por 4, o terceiro por 3 e o quarto por 2. O resultado parcial de cada posição deve ser somado e o resultado final da soma deverá ser divido por 16. O resto da divisão deverá ser convertido para hexadecimal, sendo este então o dígito verificador.
  
  Exemplo: Matrícula = 9876
  
 Cálculo:
 9 * 5 = 45
 8 * 4 = 32
 7 * 3 = 21
 6 * 2 = 12
 Total = 45 + 32 + 21 + 12 = 110
 
 Resto da divisão de 110 por 16 é igual a 14.
 O número 14 em base 16 é "E". Este é o dígito verificador da matrícula.
 Matrícula completa = 9876-E
 
 Pede-se:
 1 -  Ler as matrículas que estão no arquivo matriculasSemDV.txt e gerar um arquivo de saída matriculasComDV.txt com as matrículas completas, conforme regra de formação descrita acima.
 
 Exemplo:
 
| matriculasSemDV.txt | matriculasComDV.txt |
| --------- |:-----------:|
| 9876      | 9876-E      |
| 9876      | 9992-0      |

2 - Ler as matrículas que estão no arquivo matriculasParaVerificar.txt e gerar um arquivo matriculasVerificadas.txt com as matrículas e um indicador de "verdadeiro" ou "falso" ao lado de cada matrícula, separado por espaço.

 Exemplo:
 
| matriculasParaVerificar.txt | matriculasVerificadas.txt |
| --------- |:-----------:|
| 9876-E      | 9876-E Verdadeiro     |
| 9992-2      | 9992-0 Falso          |

Obs.: O desenvolvimento de testes unitários é um ponto positivo.
