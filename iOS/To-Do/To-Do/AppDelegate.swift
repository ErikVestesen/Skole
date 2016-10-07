//
//  AppDelegate.swift
//  To-Do
//
//  Created by Kaj Schermer Didriksen on 01/09/2016.
//  Copyright © 2016 Kaj Schermer Didriksen. All rights reserved.
//

import UIKit

@UIApplicationMain
class AppDelegate: UIResponder, UIApplicationDelegate {

    var window: UIWindow?
    let stateController = StateController()


    func application(application: UIApplication, didFinishLaunchingWithOptions launchOptions: [NSObject: AnyObject]?) -> Bool {
        
        if let navigationController = window?.rootViewController as? UINavigationController,
            let JSONController = navigationController.viewControllers.first as? JSONController {
            
            JSONController.stateController = stateController
        }
        
        return true
    }
    
    

    func applicationWillResignActive(application: UIApplication) {
        stateController.save()
    }

    func applicationWillTerminate(application: UIApplication) {
        stateController.save()
    }


}

