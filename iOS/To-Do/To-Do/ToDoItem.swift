//
//  ToDoItem.swift
//  To-Do
//
//  Created by Kaj Schermer Didriksen on 08/09/2016.
//  Copyright © 2016 Kaj Schermer Didriksen. All rights reserved.
//
/*
import Foundation

class ToDoItem: NSObject, NSCoding {
    let name: String
    let creationDate: NSDate
    var completed: Bool
    
    init(name: String, creationDate: NSDate, completed: Bool) {
        self.name = name
        self.creationDate = creationDate
        self.completed = completed
    }
    
    /*
    Decoding a TodoItem and instantiate it
    It can fail, so the ? at the end of the init.
     This one is required by the protocol
    */
 
    required init?(coder aDecoder: NSCoder) {
        name = aDecoder.decodeObjectForKey(Keys.Name.rawValue) as! String
        creationDate = aDecoder.decodeObjectForKey(Keys.CreationDate.rawValue) as! NSDate
        completed = aDecoder.decodeObjectForKey(Keys.Completed.rawValue) as! Bool
    }
    
    /*
    My ToDoItem should be able to encode itself so others can store it
     This one is not required by the protocol, but if you provide
     it It will be called by someone so the ToDoItem is serialized.
    */
    func encodeWithCoder(aCoder: NSCoder) {
        aCoder.encodeObject(name, forKey: Keys.Name.rawValue)
        aCoder.encodeObject(creationDate, forKey: Keys.CreationDate.rawValue)
        aCoder.encodeObject(completed, forKey: Keys.Completed.rawValue)
    }
    
    enum Keys: String {
        case Name = "name"
        case Completed = "completed"
        case CreationDate = "creationdate"
    }
    

}*/
