[h1]Be Quiet![/h1]

Silence that darn yippy dog! Or any other card by id.

By default, this mod quiets the dog and cat cards.

[h1]Settings[/h1]
[table]
[tr]
[td]Name
[/td]
[td]Description
[/td]
[td]Default
[/td]
[/tr]
[tr]
[td]Card List
[/td]
[td]A comma delimited list of card ids to silence.  For example, old_dog
[/td]
[td]dog, old_dog, cat, old_cat
[/td]
[/tr]
[/table]

[h1]Settings Limit Issue[/h1]

[i]This config issue will not affect most users.  It only affects users that want to add additional cards[/i]

Currently there is an issue in the config UI where the list of cards is limited.
Hopefully this will be addressed soon.

If there is a need to add addtional cards, the config.json can be edited directly.

The config is located at
[code]
[Steam Directory]\steamapps\workshop\content\1948280\3018516785\config.json
[/code]

When not running the game, add any cards to the "Card List".  If the config.json is empty, use the template below
[code]
{
  "Card List": "dog,old_dog,cat,old_cat"
}
[/code]

After editing, do not go into this mod's configuration in the game, otherwise, the Card List may be truncated.

[h1]Credits[/h1]

Created based on suggestion from Steam user vladspellbinder.

[h1]Source[/h1]

https://github.com/NBKRedSpy/Stacklands-BeQuiet

[h1]Change Log[/h1]

[h2]1.1.0[/h2]
[list]
[*]Added cats.
[/list]
