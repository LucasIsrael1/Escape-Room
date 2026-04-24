# Desenvolvimento 3D com Unity
**Por Lucas Israel Montagna - nº 33454**

Para o trabalho prático de Tecnologias Multimédia, foi desenvolvido este jogo 3D com o motor Unity Engine **6000.3.9f1**. Neste jogo, foram utilizados modelos 3D, texturas, animações e ficheiros de áudio criados por mim especificamente para este jogo.

O jogo corresponde ao tema proposto de Escape Room, contendo múltiplos níveis em que o jogador deve solucionar pequenos puzzles para abrir a porta de saída e prosseguir.

## Jogabilidade

O jogador controla uma lontra, podendo movimentar-se com as setas do teclado, ou com WASD, e pode pular ao pressionar espaço.

Um contador exibe a quantidade de frutas coletadas e o total necessário na interface, e quando todas as frutas são colhidas dos arbustos presentes no mapa a porta de saída é aberta para que o jogador possa prosseguir ao próximo nível.

Além dos arbustos, há quatro tipos de objetos encontrados nos níveis: caixas, botões, plataformas  e espinhos. As caixas são objetos simples que podem ser empurradas pelo jogador, sendo úteis para alcançar áreas mais altas ou pressionar botões.

Quando um determinado botão ou conjunto de botões é ativado, uma plataforma correspondente começa a mover-se a uma nova posição, e retorna à posição original quando desativada. Por fim, os espinhos causam um Game Over quando encostados pelo jogador. Porém, caixas podem ser colocadas em cima dos espinhos para criar um caminho seguro.

A câmera do jogo segue os movimentos do jogador, mas mantém-se sempre na mesma posição relativa e ângulo de visão. Porém, para que os controles sentissem-se mais naturais, a velocidade do jogador no eixo Z foi artificialmente aumentada, uma vez que a perspectiva fazia que os movimentos parecessem mais lentos ao se aproximar ou afastar da câmera.

## Instalação

O repositório contém o projeto Unity do jogo desenvolvido. Para visualizar e correr o jogo, é necessário efetuar download do repositório e extrair a pasta compactada em seu diretório desejado. Então, basta abrir o Unity Hub, clicar em "Add" e "Add project form disk", e encontrar o diretório em que o projeto foi colocado. Após isso, o projeto deverá estar listado no Unity Hub para ser aberto a qualquer momento.

Ao abrir o projeto, apenas selecione a cena Menu encontrada na pasta Scenes, caso não já esteja selecionada, e pressionar o botão de Play acima da visão da cena. É recomendado maximizar a janela Game ao jogar, devido ao design das interfaces.

## Elementos Multimédia

### Gráficos

Devido à minha experiência anterior com pixel art e com o desenvolvimento de modificações para o jogo Minecraft, preferi utilizar modelos voxel para este jogo, com texturas pixeladas de baixa resolução.

Para construir os modelos 3D e criar suas animações, foi utilizada a aplicação Blockbench, devido à minha experiência prévia com a ferramenta. Para as texturas, usei meu editor de imagens de costume, Paint.NET.

O terreno do jogo é composto modelos alinhados a uma grelha imaginária, podendo ser facilmente dividido em cubos. Porém, para reduzir a quantidade de modelos individuais a cada momento, também foram criados modelos maiores que agrupam uma área maior em um único mesh.

### Áudio

Os efeitos sonoros do jogo foram feitos por mim com a aplicação web ChipTone, por meio da modificação dos parâmetros de sons predefinidos para melhor combinar com as necessidades do jogo.

A música de fundo é uma composição original, feita digitalmente com o programa LMMS.