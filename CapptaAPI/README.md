# Introdução
   Projeto desenvolvido em *.NET 5* utilizando o template de *_API_*. A arquitetura do projeto foi projetada utilizando alguns conceitos simples de Arquitetura de Software.
  
 
# Dependencias
 * .NET 5
 * Visual Studio 2019
 
# Projeto 
 
 ## API
 
 O projeto API foi configurado com swagger. Nele pode ser seguido o seguinte fluxo para teste:
 
 <details>
  <summary>
    <b>Movimentar Sondas</b> - <i>retornar a ultima posição das duas sondas envidas.</i>
  </summary>
  <br/>
  
  <b>Endpoint:</b> `Post /sonda`
  <br /><br />
  ```
  [
  {
    "coordenadas": "1 2 N",
    "movimentos": "LMLMLMLMM"
  },
  {
    "coordenadas": "3 3 E",
    "movimentos": "MMRMMRMRRM"
  }
]
  ...
  ]
  ```
</details>
 






