# MG5
## Devlog
1. NavMesh is better when the character just needs to walk to a spot and find the path by itself. Physics is better when you need jumping or getting pushed around. League of Legends makes sense with NavMesh because you click and your character walks there around walls. Fall Guys doesn't, because players jump and get knocked around, which needs physics.

2. The loop checks every bird in the _birds array, from index 0 to the end. Vector3.Distance gets how far each bird is from the player. If a bird is within _interactDistance (3) of the player, it runs away.

## Open-Source Assets
- [Quirky animal 3D models](https://assetstore.unity.com/packages/3d/characters/animals/quirky-series-free-animals-pack-178235)
- [Mountain fantasy environment models](https://www.fab.com/listings/60487a72-3f20-4bb2-aa78-247ed1582656)