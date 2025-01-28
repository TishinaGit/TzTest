using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SceneContext : MonoInstaller
{
    public GameObject PlayerPrefab;
    public List<Item> Items;

    public override void InstallBindings()
    {
        ListItemsObject();

        Player(); 
    }

    public void Player()
    {
        PlayerController playerController = Container.InstantiatePrefabForComponent<PlayerController>(PlayerPrefab);
        Container.Bind<PlayerController>().FromInstance(playerController).AsSingle();
    }
    public void ListItemsObject() => Container.Bind<List<Item>>().FromInstance(Items).AsSingle();

}
