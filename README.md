# Pixygon — Dialogue

Localized dialogue lines, conversation triggers, and procedural NPC name/chatter generation for Pixygon games.

## Overview

This package drives in-game conversations. Authored lines live in `DialogueStub` ScriptableObjects with per-language text, `DialogueTrigger` attaches ordered line sequences to level objects, and `DialogueMenu` renders the active line. For ambient or filler NPCs it also ships procedural generators that fabricate random names and personality-flavored one-liners, so a level can be populated with talkers without authoring every line. It sits on top of `com.pixygon.core` (level objects) and `com.pixygon.actor` (the `Character` speaker data).

## Key types

| Type | What it is |
| --- | --- |
| `DialogueStub` | ScriptableObject holding one line of dialogue in six languages plus its speaking `Character`; `GetText(Languages)` returns the localized string. |
| `DialogueLine` | `[Serializable]` row pairing a `DialogueStub` with an `_onFinish` UnityEvent; exposes `Text`, `Character`, and `HasText`. |
| `DialogueTrigger` | `LevelObject` carrying an ordered `DialogueLine[]`; tracks `IsTriggered` and can reset on respawn. |
| `DialogueMenu` | MonoBehaviour UI that shows/hides a title + body via `StartDialogue(title, text)` / `CloseDialogue()` (TextMeshPro). |
| `DialogueTarget` | MonoBehaviour on an NPC; serves either authored dialogue or, when `_isRandomized`, a generated name + personality-based line. |
| `Languages` | Enum of supported locales — English, Norwegian, Ukrainian, Russian, French, Spanish. |
| `DialogueGenerator` | MonoBehaviour exposing `static GenerateRandomDialogue(Personality)`; picks a random line from its data per personality. |
| `DialogueGenerator.Personality` | Enum — Friendly, Grumpy, Curious, Lazy, Adventurous, Wise. |
| `DialogueGeneratorData` | ScriptableObject — the line pools backing each `Personality`. |
| `NameGenerator` | Plain class; `GenerateRandomName(NameGeneratorData)` composes title / first / middle / last / nickname. |
| `NameGeneratorData` | ScriptableObject — name pools and toggles for middle name, title, and nickname. |

## How games use it

1. Author dialogue: create `DialogueStub` assets (`Pixygon/Dialogue/New DialogueStub`), filling in each language and the speaking `Character`.
2. Drop a `DialogueTrigger` on a level object and populate its `Lines` array with `DialogueStub` references and per-line `_onFinish` events.
3. On trigger, walk `Lines` and feed each into the UI:

```csharp
foreach (var line in trigger.Lines) {
    if (!line.HasText) continue;
    dialogueMenu.StartDialogue(line.Character.name, line.Text);
    // await player input, then…
    line._onFinish.Invoke();
}
dialogueMenu.CloseDialogue();
trigger.IsTriggered = true;
```

4. For ambient NPCs, set `DialogueTarget._isRandomized` and assign a `NameGeneratorData`; on `Start` it rolls a name and `Personality`, and `StartDialogue()` pulls a line via `DialogueGenerator.GenerateRandomDialogue`.

## Dependencies

- `com.pixygon.actor` (0.5.0) — supplies the `Character` type used as the speaker on every dialogue stub and line.
- `com.pixygon.micro` (0.7.4) — core Pixygon engine/runtime services the package builds on.

(`DialogueTrigger` also extends `LevelObject` from `com.pixygon.core`, pulled in transitively.)

## Install

```json
"com.pixygon.dialogue": "https://github.com/Pixygon/com.pixygon.dialogue.git"
```
