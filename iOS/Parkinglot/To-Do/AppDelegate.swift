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
    let parkingstateController = ParkinglotStateController()
    let toiletStateController  = ToiletStateController()


    func application(application: UIApplication, didFinishLaunchingWithOptions launchOptions: [NSObject: AnyObject]?) -> Bool {
        
      if let tabbarController = window?.rootViewController as? UITabBarController {
            if let navigationController = tabbarController.viewControllers?.first as? UINavigationController,
              let parkinglotListViewController = navigationController.viewControllers.first as? ParkinglotListTableViewController {
              parkinglotListViewController.stateController = parkingstateController
        }
        if let toiletMapViewController = tabbarController.viewControllers?[1] as? ToiletLocationViewController {
          toiletMapViewController.stateController = toiletStateController
        }
      }
      
        return true
    }


}

