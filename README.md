# ProjectBungalowSample
These are sample files from Project Bungalow, an in development game created in Unity. 

# Contents
1. Cargo Manager
    - CargoManager facilitates the addition and removal of resources from the referenced Scriptable Objects used by other scripts.
3. Scriptable Objects
   - CargoData: Dictionaries with key value pairing of ResourceItemData and it's quantity.
   - ResourceItemData: The basic Resource scriptable object that is used by various scripts in the project
5. Tests
   - A Playmode test that verifies the basic addition and transfer functionality of the CargoManager
7. Future Improvements
  - Currently the project has an over reliance on singeltons. The future refactor of this area would possible mean moving some of the functionality of CargoManager into CargoData. The intention being that scripts could directly reference the scriptable object instead of needing a reference to GameManager.Instance().CargoManager().SubCargoData for example.
  - I think this area could benefit from some namespacing.
