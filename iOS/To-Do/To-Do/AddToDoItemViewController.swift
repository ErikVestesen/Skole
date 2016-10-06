//
//  AddToDoItemViewController.swift
//  To-Do
//
//  Created by Kaj Schermer Didriksen on 15/09/2016.
//  Copyright © 2016 Kaj Schermer Didriksen. All rights reserved.
//
/*
import UIKit

class AddToDoItemViewController: UIViewController {

    @IBOutlet weak var nameTextField: UITextField!
    @IBOutlet weak var saveButton: UIBarButtonItem!
    @IBOutlet weak var cancelButton: UIBarButtonItem!
    
    var stateController: StateController?
    
    // clicking save or cancel excecutes a seque
    // this prepare... excecutes prior to the seque.
    override func prepareForSegue(segue: UIStoryboardSegue, sender: AnyObject?) {
        
        guard let tappedButton = sender as? UIBarButtonItem where tappedButton  != cancelButton else {
            return
        }
        
        guard let text = nameTextField.text else {
            return
        }
        
        let todoItem = ToDoItem(name: text, creationDate: NSDate(), completed: false)
        
        stateController?.addItem(todoItem)
    }
    
    
    
}
 */
