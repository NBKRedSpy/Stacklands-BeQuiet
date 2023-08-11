# Be Quiet!

Silence that darn yippy dog! 

Also silences cats and optionally silences dust bins.

Other cards can be added to the list by their card id.

# Settings

|Name|Description|Default|
|--|--|--|
|Card List|A comma delimited list of card ids to silence.  For example, old_dog|dog, old_dog, cat, old_cat|
|Mute dustbin|false|If enabled, the dustbin will not make a sound when cards are destroyed.  This is a louder sound.|
|Mute dustbin card destroy|false|If enabled, will prevent the card destroyed by a dustbin from making a sound.  This is a quiet tick.|

# Settings Limit Issue

*This config issue will not affect most users.  It only affects users that want to add additional cards*

Currently there is an issue in the config UI where the list of cards is limited.
Hopefully this will be addressed soon.

If there is a need to add addtional cards, the config.json can be edited directly.

The config is located at
```
[Steam Directory]\steamapps\workshop\content\1948280\3018516785\config.json
```

When not running the game, add any cards to the "Card List".  If the config.json is empty, use the template below

```
{
  "Card List": "dog,old_dog,cat,old_cat"
}
```

After editing, do not go into this mod's configuration in the game, otherwise, the Card List may be truncated.

# Credits
Created based on suggestion from Steam user vladspellbinder.
Dustbin mute suggested by hade.

# Source
https://github.com/NBKRedSpy/Stacklands-BeQuiet


# Change Log

## 1.2.0

* Added the ability to mute dust bins as well.  (Disabled by default)
* Requested by hade on the modding Discord.

## 1.1.0

* Added cats.

