using System.Collections.Generic;

namespace WarBox.Content;

internal static class WarBoxMisc
{
    public static void Init()
    {
        AddNameGenerators();
    }

    private static void AddNameGenerators()
    {
        NameGeneratorAsset gun_namegenerator = new NameGeneratorAsset
        {
            id = "gun_name"
        };
        gun_namegenerator.addPartGroup("M,MG,SG,G,MP,AK,XM,P,HK,RPG,FIM,AEK,AN,FAMAS,UMP,AR,LR,SR,SMG,LMG,SCAR,MAC,TEC,PM,PMM,USP,PP,PPK,AWP,AWM,TAR,RPK,PPSh,DP");
        gun_namegenerator.addPartGroup("-");
        gun_namegenerator.addPartGroup("1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100");
        gun_namegenerator.addPartGroup("A1,A2,A3,A4,MK1,MK2,MK3,MK4,A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z");
        gun_namegenerator.addTemplate("Part_group");
        AssetManager.name_generator.add(gun_namegenerator);

        CreateNameSet(new NameGeneratorAsset
        {
            id = "tank_name",
            onomastics_templates = new List<string> { "`0_###u|0:tank`" }
        });

        CreateNameSet(new NameGeneratorAsset
        {
            id = "apc_name",
            onomastics_templates = new List<string> { "`0_###u|0:apc`" }
        });

        CreateNameSet(new NameGeneratorAsset
        {
            id = "ifv_name",
            onomastics_templates = new List<string> { "`0_###u|0:ifv`" }
        });

        CreateNameSet(new NameGeneratorAsset
        {
            id = "spg_name",
            onomastics_templates = new List<string> { "`0_###u|0:spg`" }
        });

        CreateNameSet(new NameGeneratorAsset
        {
            id = "heli_name",
            onomastics_templates = new List<string> { "`0_###u|0:heli`" }
        });
    }

    private static void CreateNameSet(NameGeneratorAsset name_generator)
    {
        AssetManager.name_generator.add(name_generator);
        string id = name_generator.id;
        AssetManager.name_sets.add(new NameSetAsset
        {
            id = id,
            city = id,
            clan = id,
            culture = id,
            family = id,
            kingdom = id,
            language = id,
            unit = id,
            religion = id
        });
    }
}