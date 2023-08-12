[h1]Be Quiet![/h1]

Silence that darn yippy dog!

Also silences cats and optionally silences dust bins.

Other cards can be added to the list by their card id.

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
[tr]
[td]Mute dustbin
[/td]
[td]false
[/td]
[td]If enabled, the dustbin will not make a sound when cards are destroyed.  This is a louder sound.
[/td]
[/tr]
[tr]
[td]Mute dustbin card destroy
[/td]
[td]false
[/td]
[td]If enabled, will prevent the card destroyed by a dustbin from making a sound.  This is a quiet tick.
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
Dustbin mute suggested by hade.

[h1]Source[/h1]

https://github.com/NBKRedSpy/Stacklands-BeQuiet

[h1]Change Log[/h1]

[h2]1.2.1[/h2]
[list]
[*]Fixed exception being thrown on empty audio play.
[/list]

[h2]1.2.0[/h2]
[list]
[*]Added the ability to mute dust bins as well.  (Disabled by default)
[*]Requested by hade on the modding Discord.
[/list]

[h2]1.1.0[/h2]
[list]
[*]Added cats.
[/list]
