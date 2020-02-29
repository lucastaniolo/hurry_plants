![#](https://upload.wikimedia.org/wikipedia/commons/8/81/20_century_boys_logo.png)

# oldBoys Studio Style Guide

*A tentative guide to unified asset naming, guidelines and practices*

_This document is currently work-in-progress_

## Scripting/Programming Disclaimer

This document does not apply to Scripts(of any language) assets or conventions regarding variable or code syntax conventions. Will be updated on the topic as the need arises.

## General Terminology

##### Unity Levels/Scene/Maps

Although the terms levels, scene and maps can be used interchangeably to refer to Unity Scenes files, this guide will only use the term "Scene" or "Unity Scene".

##### Unity Render Pipelines

As of version 2019.3, Lightweigth Render Pipeline was renamed to Universal Render Pipeline, so it will only be referred as URP for brevity. High Definition Render Pipeline is referred throughout the guide as HDRP.

##### Work & Publish

oldBoys Studio uses a Work & Publish pipeline for all source content creation. Local work-in-progress assets are referred as working files. Final files ready to opened and having its content exported are referred as Published Files. Only Published Files are shared in the asset repositories. Whenever possible, Published Files export settings should be configured to export its content in the right format and settings to the appropriate Unity folder.

##### Cases

Examples of commonly used cases

> ###### PascalCase
>
> Capitalize every word and remove all spaces, e.g. `DesertEagle`, `StyleGuide`, `ASeriesOfWords`.
> 
> ###### camelCase
>
> The first letter is always lowercase but every following word starts with uppercase, e.g. `desertEagle`, `styleGuide`, `aSeriesOfWords`.
>
> ###### Snake_case
>
> Words can arbitrarily start upper or lowercase but words are separated by an underscore, e.g. `desert_Eagle`, `Style_Guide`, `a_Series_of_Words`.

**oldBoys Studio employs a camelCase standard for naming assets in general, with PascalCase being reserved only for folders inside the project and Game Objects/Prefabs. No spaces and special characters.**

By default Unity creates Game Objects with compound names with spaces. Take the time to remove the space if the created Game Object is going to maintained in the scene or converted to a Prefab.

##### Parameters/Properties

Terms used interchangeably to refer to public exposed variables in Unity's Shader Graph. This guide will only use the term "Property(ies)".

##### Word Standards/Semantics 

oldBoys Studio adopts U.S. English semantics and practices. Meaning, if an asset contains words that can be written in a different way based on region to describe the same thing, opt for the U.S. English way, e.g. `Gray` (and not UK's `Grey`), `Center` (and not Canada's `Centre`), `Cookie`(and not UK's `Biscuit`).

## 0. Principles

### 0.1 If the project has a convention, you should follow it to the best of your abilities.

If dealing with an asset or asset type that causes weird effects on existing conventions, name it reasonably along with similar cases until a proper solution is developed. If renaming becomes unfeasible, use the makeshift solution until the next project.

### 0.2 All structure and assets inside the project should look like a single person created it, no matter how many people contributed.

Moving from one project to another should not cause a re-learning of style and structure. Conforming to a style guide removes unneeded guesswork and ambiguities.

It also allows for more productive creation and maintenance as one does not need to think about style, simply follow instructions. This style guide is written with best practices in mind, meaning that by following this style guide you will also minimize hard to track issues.

### 0.3 Friends do not let friends have bad style.

If someone is working either against a style guide or no style guide, try to correct them. It is far easier to help and to ask for help when people are consistent. Nobody likes to help untangle someone's Shader Graph spaghetti or deal with assets with names they can't understand.

## Table of Contents

> 1. [Asset Naming Conventions](#anc)
> 1. [Directory Structure](#structure)
> 1. [Game Objects](#go)
> 1. [Shader Graphs / FX Graph / Any Node-Based Editor inside Unity](#sg)
> 1. [Static Meshes](#geo)
> 1. [Skinned Meshes](#sk)
> 1. [Unity Scenes](#scene)
> 1. [Textures and Materials](#tex)
> 1. [Animation Clips](#ac)
> 1. [Prefabs, Nesteds and Variants](#pf)
> 1. [Platform Considerations and Specifics](#plat)

<a name="anc"></a>
<a name="1"></a>
## 1. Asset Naming Conventions

Naming conventions should be treated as law. A project that conforms to a naming convention is able to have its assets managed, searched, and maintained with ease. Also, as of Unity 2019.3, asset's preview thumbnails have refresh and display issues, so having a style guide helps distinguishing assets when the preview won't help you.

Most assets are sufixed with sufixes being generally an acronym of the asset type preceded by underscores. That way, assets with similar names or variations and all its related content(materials, textures, etc) can stay close to each other inside the project directory folders. 

### 1.1 Base Asset Name - `baseAssetName_variation__suffix(Asset Type)_subcategory(Asset Type)`

*Note that suffix is preceded by two underscores*

All assets should have a _Base Asset Name_. A Base Asset Name represents a logical grouping of related assets. Any asset that is part of this logical group should follow the the standard of `baseAssetName_variation__suffix(Asset Type)_subcategory(Asset Type)`.

Keeping the pattern `baseAssetName_variation__suffix(Asset Type)_subcategory(Asset Type)` in mind and using common sense is generally enough to warrant good asset names. Here are some detailed rules regarding each element.

Suffix is determined by the asset type following the Asset Name Modifier Tables. The reason why two underscores are used before the Asset Type Suffix is to safeguard against situations where the variation could mess the desired order to keep similar assets organized inside the folder. Examples below.

`baseAssetName` should be determined by short and easily recognizable name related to the context of this group of assets. For example, if you had a character named `bossPlant`, all of `bossPlant`'s assets would have the _Base Asset Name_ of `bossPlant`.

For unique and specific variations of assets, `variation` is either a short and easily recognizable name that represents logical grouping of assets that are a subset of an asset's base name. For example, 
if `bossPlant` had multiple skins these skins should still use `bossPlant` as the `baseAssetName` but include a recognizable variation. A _Pirate_ skin would be referred to as `blossPlant_pirate` and a _Retro_ skin would be referred to as `bossPlant_retro`.

For unique but generic variations of assets, `variation` is a two digit number starting at 01. For example, if you have to create generic rocks, they would be named `rock_01`, `rock_02`, `rock_03`, etc. Except for rare exceptions, you should never require a three digit variation number. If you have more than 100 assets, you should consider organizing them with different base names or using multiple variation names.

Depending on how your asset variations are made, you can chain together variations names. For example, if you are creating floor assets you should use the base name `flooring` with chained variations such as `flooring_marble_01`, `flooring_woodOak_01`, etc.

You can see in the examples above that whenever the `variation` can have multiple descriptive words in a similar category, use the standard camelCase to separate them. e.g. `rock_mossWet`, `rock_mossDry`. Note that the adjective comes last, as the noun defining the variation is used to group similar assets in folder. This rule can also be applied to the baseAssetName itself, e.g. `bossPlant`, `bossAlien`.

#### 1.1 Examples

##### 1.1e1 bossPlant

| Asset Type                         | Asset Name                                                 |
| ---------------------------------- | ---------------------------------------------------------- |
| Skinned Mesh                       | bossPlant__sk                                              |
| Shader Graph                       | bossPlant__shaderGraph                                     |
| Material                           | bossPlant__mat                                             |
| Material(Body)                     | bossPlant__matBody                                         |
| Material(Head)                     | bossPlant__matHead                                         |
| Texture(Albedo/Transparency)       | bossPlant__tex_albedoTransparency                          |
| Texture(Body-Albedo/Transparency)  | bossPlant__texBody_albedoTransparency                      |
| Prefab                             | BossPlant                                                  |
| Prefab Variant                     | BossPlant_Damaged                                          |

##### 1.1e2 Bad example - `bossPlant` and `bossPlant` with `pirate` skin: Order of related assets inside a directory using only one underscore for Asset Type Suffix.

> bossPlant_geo
>
> bossPlant_mat
>
> bossPlant_pirate_geo
>
> bossPlant_pirate_mat
>
> bossPlant_pirate_tex_normal
>
> bossPlant_tex_normal

##### 1.1e3 Proposed convention example - `bossPlant` and `bossPlant` with `pirate` skin: Order of related assets inside a directory using two underscores for Asset Type Suffix

> bossPlant__geo
>
> bossPlant__mat
>
> bossPlant__tex_normal
>
> bossPlant_pirate__geo
>
> bossPlant_pirate__mat
>
> bossPlant_pirate__tex_normal

### 1.2 Asset Name Modifiers

> 1.2.1 [Most Common](#anc-common)

> 1.2.2 [Textures](#anc-textures)

> 1.2.3 [Materials](#anc-materials)

> 1.2.4 [Animation](#anc-animation)

> 1.2.5 [Rendering](#anc-rendering)

> 1.2.6 [UI](#anc-ui)

> 1.2.7 [VFX](#anc-vfx)

> 1.2.8 [Terrain](#anc-terrain)

> 1.2.9 [Sprites](#anc-sprites)

<a name="anc-common"></a>
<a name="1.2.1"></a>
#### 1.2.1 Most Common

| Asset Type                         | Suffix               | Subcategory                      | Notes                                                                                                                                                                                                                                |   
| ---------------------------------- | -------------------- | -------------------------------- | --------------------------------------------------------------------------------------------------------------------------------                                                                                                     |
| Unity Scene                        | __scene              |                                  | Used for Master/Persistent Scene                                                                                                                                                                                                     |
| Unity Subscene                     | __scene              | _"scenePurpose"                  | Used for Multi-Scene workflows (e.g. tavern__scene_props)                                                                                                                                                                            |
| Material                           | __mat                | "MaterialPart"                   | Optional subcategory for assets with multiple submaterials/texture sets. Appended after main suffix without underscores, with capital letter, respecting the camelCase standard(e.g. bossPlant_matHead)                              |
| Static Mesh                        | __geo                |                                  | Non-deforming meshes. Generally receives pre-baked data (e.g. Lightmaps)                                                                                                                                                             |
| Skinned Mesh                       | __sk                 |                                  | Deforming meshes                                                                                                                                                                                                                     |
| Texture                            | __tex                | "MaterialPart" _"texturePurpose" | Optional "MaterialPart" subcategory for assets with multiple submaterials. Appended after main suffix without underscores, with capital letter, respecting the camelCase standard. For "texturePupose" See [Textures](#anc-textures) |                                                               
| Prefab                             | None                 | _Variant                         | Prefabs are the only asset types without defining suffixes. BaseAssetName and its following prefab variants should be PascalCase                                                                                                     |

<a name="anc-textures"></a>
<a name="1.2.2"></a>
#### 1.2.2 Textures

When in doubt of which subcategory to use on textures containing unusual information, opt for clarity over brevity.

Note that for Unity's default shaders(such as _URP Lit_) that expects information in the texture Alpha Channel on some map slots, always add the name of the map that goes into the Alpha Channel, even if the materials is opaque and the channel is not being used (e.g. `wallBrick_tex_albedoTransparency`). 

| Asset Type                          | Suffix                | Subcategory                                 | Notes                                                                                                                                                                                                                                   |   
| ----------------------------------- | --------------------- | ------------------------------------------- | --------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Texture                             | __tex                 | "MaterialPart"                              | SubCategory can be left blank if the texture is used as dummy or without a specific shader output in mind(e.g. baseGray__tex). Optional "MaterialPart" for assets with multiple submaterials(e.g. bossPlant_texHead_metallicSmoothness) |
| Texture(URP Lit-Base Map Slot)      | __tex                 | "MaterialPart"_albedoTransparency           | Transparency Map(if used) is always stored in the image Alpha Channel                                                                                                                                                                   |
| Texture(URP Lit-Metallic Map Slot)  | __tex                 | "MaterialPart"_metallicSmoothness           | Smoothness Map(if used) is always stored in the Metallic Alpha                                                                                                                                                                          |
| Texture(URP Lit-Normal Map Slot)    | __tex                 | "MaterialPart"_normal                       |                                                                                                                                                                                                                                         |
| Texture(URP Lit-Occlusion Map Slot) | __tex                 | "MaterialPart"_occlusion                    | Ambient Occlusion                                                                                                                                                                                                                       |
| Texture(URP Lit-Emission Map Slot)  | __tex                 | "MaterialPart"_emission                     | Emissive Textures                                                                                                                                                                                                                       |                                                               
| Texture(Custom Packing Example)     | __tex                 | "MaterialPart"_occlusionSmoothnessMetallic  | Occlusion in Red Channel, Smoothness in Green Channel, Metallic on Blue Channel                                                                                                                                                         |
| Texture(Cubemaps)                   | __tex                 | _cube                                       | Generally used for HDRIs                                                                                                                                                                                                                |
| Render Texture                      | __renderTex           |                                             | Special kind of textures generated & updated at runtime for some special effects                                                                                                                                                        |

<a name="anc-materials"></a>
<a name="1.2.3"></a>
#### 1.2.3 Materials

Note that when creating materials from a Shader Graph, the Shader Graph name is appended to the new material asset. Remember to rename it properly.

| Asset Type                         | Suffix               | Subcategory                      | Notes                                                                                                                                                                                          |   
| ---------------------------------- | -------------------- | -------------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Material                           | __mat                | "MaterialPart"                   | Optional "MaterialPart" subcategory for assets with multiple submaterials/texture sets. Appended after main suffix without underscores, with capital letter, respecting the camelCase standard |
| Shader Graph                       | __shaderGraph        | "MaterialPart"                   | Optional "MaterialPart" subcategory for assets with multiple submaterials/texture sets. Appended after main suffix without underscores, with capital letter, respecting the camelCase standard |
| Subgraph                           | __subGraph           |                                  |                                                                                                                                                                                                |

<a name="anc-animation"></a>
<a name="1.2.4"></a>
#### 1.2.4 Animation

| Asset Type                         | Suffix                | Subcategory                      | Notes                                                                 |   
| ---------------------------------- | --------------------- | -------------------------------- | --------------------------------------------------------------------- |
| Skinned Mesh                       | __sk                  |                                  | Deforming meshes                                                      |
| FBX file with animated joints      |                       | @clipName                        | Unity specific convention. e.g. bossPlant__sk@idle                    |
| FBX file with animated Joints      |                       | @clipName_"variation"            | e.g. bossPlant__sk@idleDab_left, soldierEnemy__sk@aimingWalk_backward |
| Animation                          | __animation           |                                  | Unity's animation files                                               |
| Animation Controller               | __animationController |                                  |                                                                       |                      

<a name="anc-rendering"></a>
<a name="1.2.5"></a>
#### 1.2.5 Rendering

| Asset Type                         | Suffix               | Subcategory                      | Notes                                                                            |   
| ---------------------------------- | -------------------- | -------------------------------- | -------------------------------------------------------------------------------- |
| Universal Render Pipeline Asset    | __urp                | _renderer                        | Stores project-wide render settings                                              |
| Post Process Profile               | __postProcess        |                                  |                                                                                  |
| Volume Profile                     | __volumeProfile      | _"volumePurpose"                 | Generic Volume Asset. Describe its purpose with subcategories(e.g. _postProcess) |

<a name="anc-ui"></a>
<a name="1.2.6"></a>
#### 1.2.6 UI
**W.I.P.**

<a name="anc-vfx"></a>
<a name="1.2.7"></a>
#### 1.2.7 VFX
**W.I.P.**

<a name="anc-terrain"></a>
<a name="1.2.8"></a>
#### 1.2.8 Terrain
**W.I.P.**

<a name="anc-sprites"></a>
<a name="1.2.9"></a>
#### 1.2.9 Sprites
**W.I.P.**

<a name="2"></a>
<a name="structure"></a>
## 2. Directory Structure

Prefer horizontal folder hierarchy over deep vertical ones. Meaning, avoid burying content inside many subfolders. Use Unity's filters and searches by asset base names and sufixes to quickly filter through content even on populated folders. Folder names are always PascalCase with no spaces or special characters, unless it comes from an external source(Unity or 3rd Party Packages). Content that is shared throughout the project(like utilities SubGraphs, dummy texturesand meshes) should be placed in a "Common" Folder.

**W.I.P.**

<a name="3"></a>
<a name="go"></a>
## 3. Game Objects

Never leave Game Objects unnamed. Reset its Transform to (0,0,0) unless explicit using transforms for something else. Names in PascalCase without spaces or special characters.

**W.I.P.**

<a name="4"></a>
<a name="sg"></a>
## 4. Shader Graphs / FX Graph / Any Node-Based Editor inside Unity
**W.I.P.**

<a name="5"></a>
<a name="geo"></a>
## 5. Static Meshes
**W.I.P.**

<a name="6"></a>
<a name="sk"></a>
## 6. Skinned Meshes
**W.I.P.**

<a name="7"></a>
<a name="scene"></a>
## 7. Unity Scenes
**W.I.P.**

<a name="8"></a>
<a name="tex"></a>
## 8. Textures & Materials

### 8.1 Textures

oldBoys Studio uses PNGs as the standard texture format for UI and Shader consuption. Please refer to Polycount's Wikia on PNG(http://wiki.polycount.com/wiki/PNG) on how to deal with Photoshop's poor handling of PNG with Alpha Channels. HDRs are used for Cubemaps. PSDs can be used for quick local tests but due to its size its better to avoid its use. Artists caught importing and using JPEGs will be shot in the kneecap, their house burned and their lands salted.

All working assets textures are _required_ to be authored at 16-bit(to avoid low precision issues) and at least double the inteded-use resolution. During export, scale the resolution back to the intended-use size and 8-bit precision. Although it is possible to clamp the texture size inside Unity, importing the image at the intended-use size will keep the project leaner and the repository lighter. If you don't know what the final resolution will be yet, 2048 is a safe temporary size.

All imported textures should be properly configured on import according to its usage. All textures except the albedoTransparency(and emission maps) **must** have the sRGB checkbox turned off.

Normal maps should be baked, authored and imported in the OpenGL(Y+) format for its Green Channel. During the baking process, make sure your baker is set to use Mikkelsen Tangent Space(MikkT) and Bitangets calculated per pixel. Your low poly mesh must be triangulated before baking with hard edges on uv seams to avoid harsh normal map gradients.

### 8.2 Materials

For URP projects, URP Lit with Metallic Workflow is the standard Material to be used. For that shader, the Transparency Map is always stored in the Albedo Alpha Channel and the Smoothness Map is always saved in the Metallic Alpha.

Shader Graphs and Subgraphs shared across multiple assets should be in a "Common" Folder, otherwise, leave it at the folder where the material to be generated and applied to the mesh will be. 

<a name="9"></a>
<a name="ac"></a>
## 9. Animation Clips Conventions
**W.I.P.**

<a name="10"></a>
<a name="pf"></a>
## 10. Prefabs, Nesteds and Variants
**W.I.P.**

<a name="11"></a>
<a name="plat"></a>
## 11. Platform Considerations and Specifics

### 11.1 PC
**W.I.P.**

### 11.1 Switch
**W.I.P.**

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
