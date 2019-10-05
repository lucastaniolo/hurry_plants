HURRY PLANTS
É um local multiplayer coop de 2~4 players.
O objetivo do jogo é conduzir todos os NPCs de cada level para a PlantaMãe antes que o tempo acabe.

A principal mecânica do jogo é lançar objetos. Cada player pode carregar e lançar apenas um objeto por vez.
Os objetos que podem ser carregados são: NPCs, outros players e bombas.

Os elementos interativos do cenário são paredes, caixas, buracos, esteiras, espinhos e portais:
- paredes bloqueiam o caminho permanentemente;
- as caixas bloqueiam o caminho mas podem ser destruídas com a bomba;
- as esteiras alteram a direção dos players automaticamente;
- buracos são onde os players podem cair resetando suas posições;
- espinhos também causam danos aos players resetando suas posições;
- os portais transportam players e objetos para outro ponto do level mantendo seu movimento.

MOVIMENTO E AÇÕES DOS PLAYERS
- quando a partida começa, cada player esta em um local fixo no level
- ao escolher uma direção, o personagem comeca a se mover constantemente na direcao escolhida
- o jogador pode se mover em 4 direçoes:  ←  ↑   ↓  →
- em movimento, carregando algum objeto ou não, ao mudar para a direção oposta o personagem para
- assim que o personagem encontra um obstaculo estatico (parede ou planta) ele muda para a direcao oposta automaticamente
- ao encostar nos espinhos ou cair em um buraco, o personagem "morre" desaparece e ressurge em seu respectivo ponto inicial
- ao passar pela esteira, o jogador tem sua velocidade dobrada, contra a corrente, sua velocidade é anulada
- ao passar por outro player ou objeto que esteja parado, o jogador o captura
- ao ser lancado, o jogador permanece a trajetoria ate que encoste em uma parede,
  seja capturado por outro player ou aperte o botao de acao para estacionar
- durante a trajetoria, o jogador não interaje com objetos parados no chao como bombas e NPCs, passa direto logo acima eles
- se, durante a trajetória o personagem colide com a bomba, um NPC, ou outro player parado,
  ele os captura pressionando o botao de acao e já estacionando na posicao do objeto capturado
- se a colisão durante a trajetoria acontecer com a bomba também em trajetoria,
  o player a captura automaticamente e estaciona no local de colisao
- carregando um objeto, o jogador os segura em sua frente,
  caso sua rotacao cause colisao do objeto com alguma parede ou outro objeto, a pose do personagem muda para carregando em cima
- em qualquer modo abaixo de 4 jogadores, quando o jogador captura e lanca um outro player,
  ele automaticamente passa a controlar o personagem em trajetoria, o que lancou fica parado
- se, carregando um player o jogador colide com os espinhos,
  ele morre o outro player cai no chao na casa em frente a parede.
  No caso de menos do que 4 jogadores, o controle passa para o personagem que sobreviveu
- se, carregando um player o jogador cai em um buraco, os dois ressurgem em suas posicoes originais do level
- se dois players colidem em trajetoria, eles estacionam em suas posicoes de colisao,
  caso nao haja chao, morrem e voltam para suas respectivas posicoes iniciais
- se a partida acabar com algum player segurando um NPC,
  o NPC é destruido e ressurge em sua posicao inicial e o player entre na animacao lose
- o jogador captura qualquer objeto interativo parado ou em trajetoria colidindo com ele
- carregando qualquer coisa, o jogador pode lançar o objeto com o botão de ação
- jogadores podem ser capturados por outros jogadores desde que estejam parados
- ao ser lançado por outro player, o jogador pode estacionar no local desejado usando o botão de ação
- objetos que estao em trajetoria são capturados automaticamente
- carregando um objeto, o jogador os segura em sua frente,
  caso sua rotacao cause colisao do objeto com alguma parede ou outro objeto, a pose do personagem muda para carregando em cima

COMPORTAMENTO DOS NPCs
- ficam parados em suas posições definidas pelo level design
- são capturados pelos players assim que colidem
- ao serem lançados, permanecem em uma trajetoria constante ate que enconstem em uma parede
- quando colidem com qualquer objeto que nao seja a planta ou player, são destruidos e ressurgem em suas respectivas posicoes iniciais
- se estao sendo carregados por um player e uma bomba explode muito proximo,
  o player o NPC e a bomba sao destruidos e retornam a suas pos iniciais
- quando jogados para a planta, não ressurgem em suas posicoes iniciais
- se o tempo acabar com um NPC em trajetoria para a planta,
  o jogo só termina quando ele a atinge, priorizando a condição de vitória
- e se o tempo acabar e NÃO for o último NPC, game over
