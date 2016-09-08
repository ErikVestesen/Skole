//
//  AppDelegate.swift
//  To-Do
//
//  Created by Erik Vestesen on 01/09/16.
//  Copyright © 2016 Erik Vestesen. All rights reserved.
//

import UIKit

@UIApplicationMain
class AppDelegate: UIResponder, UIApplicationDelegate {

    var window: UIWindow?
    let stateController = StateController()


    func application(application: UIApplication, didFinishLaunchingWithOptions launchOptions: [NSObject: AnyObject]?) -> Bool {
        
        if let navigationController = window?.rootViewController as? UINavigationController,
            let toDoItemListViewController = navigationController.viewControllers.first as? TodoListTableViewController {
                toDoItemListViewController.stateController = stateController
            }
        return true
    }

    //Enters background
    func applicationWillResignActive(application: UIApplication) {
        stateController.save()
    }
    
    //Quits app, or even deleted completely
    func applicationWillTerminate(application: UIApplication) {
        stateController.save()
    }


}

