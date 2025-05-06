# Teste Técnico C# Benner

Primeiramente, gostaria de agradecer pela oportunidade de participar desta seleção. Estou muito feliz por ter chegado a esta etapa. O teste técnico foi muito legal e um pouco desafiador. Me senti muito confortável em resolver o problema lógico e aplicar alguns dos meus conhecimentos, principalmente em estrutura de dados, que foi dominante no teste técnico como um todo. Desde já, fico muito feliz só de estar nessa etapa.

## Sobre o código

Como pedido, foram feitos quatro métodos: Connect, Disconnect, Query e LevelConnetion. Descrevi conforme a folha de problema. Então, seguir a mesma sintaxe pedida, pois tenho receio de que isso possa entrar em um teste unitário para testar a consistência do meu código.

## Exemplo de uso
```csharp
var network = new Network(8);

network.Connect(1, 6);
network.Connect(1, 2);
network.Connect(6, 2);
network.Connect(2, 4);
network.Connect(5, 8);

network.Disconnect(5, 8);

Console.WriteLine(network.Query(1, 6));
Console.WriteLine(network.Query(1, 4));
Console.WriteLine(network.Query(5, 6));
Console.WriteLine(network.Query(5, 8));
Console.WriteLine(network.Query(4, 7));

Console.WriteLine(network.LevelConnetion(1, 6));
Console.WriteLine(network.LevelConnetion(1, 4));
Console.WriteLine(network.LevelConnetion(5, 6));
Console.WriteLine(network.LevelConnetion(5, 8));
Console.WriteLine(network.LevelConnetion(4, 7));

/*Saída
True
True
False
False
False
1
2
0
0
0
*/
```
