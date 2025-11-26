class Player:
    def __init__(self, name, inventory):
        self.name = name
        self.HP = 100
        self.mana = 100
        self.level = 1
        self.xp = 0
        self.inventory = inventory

class Item:
    def __init__(self, name, type):
        self.name = name
        self.type = type

player1 = Player('Florian', [Item('Axe', 'Active'), Item('Talisman', 'Passive')])
player2 = Player('Paulian', [])

print(player1.name, player1.inventory[0].name)
print(player2.name)