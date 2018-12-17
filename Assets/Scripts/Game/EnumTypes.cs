public enum GestureTouch {
    None,First,End,Tapped,Tap,DoubleTap,Move,Static
}
public enum GestureStepTouch {
None,First,Second,Third
}

public enum GameStatus {
    None,Loading,LevelData,Rule,Generate,ShowIt,HideIt,Play,Answers
}

public enum GameStatusShowOnce {
    None,Show,Once,Lock
}

public enum LoadStatus {
    None,Wait,Open,Load,Over
}

public enum TableStatus {
    None,RegItems,PlaceAll,Over
}

public enum ConfirmButtonAction {
    None,Play,This,Ok,Menu
}

public enum GameItem {
    None,Gem,Dice,Cask
}

public enum GameAnswer {
    None,Win,Next,Drop,Repeat
}

public enum TableViewData {
    None, Table,Container,Row,Cell
}