# NiceHashQuickMiner.RichPresence

Discord Rich Presence for NiceHash QuickMiner

NiceHash QuickMiner のマイニング状況を Discord に Rich Presence として通知します。  
折角なので先週リリースされたばかりの .NET 6 + WinUI 3 で実装しています。

![Rich Presence](https://i.imgur.com/e5XbLDX.png)

![Config Window](https://i.imgur.com/3iQzDE1.png)

## How to Use / Build

ちょっとまってね

[#1652](https://github.com/microsoft/WindowsAppSDK/issues/1652) が解決されるまで CI は動きません。

## Known Issues

- 通知アイコンを触る API が未実装なので、タスクバーにアイコンが残ってしまう (通知領域にしまいたい)
- Config Window の実装が WIP
