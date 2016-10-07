//
//  ToiletLocationViewController.swift
//  Parkinglot
//
//  Created by Kaj Schermer Didriksen on 21/09/2016.
//  Copyright © 2016 Kaj Schermer Didriksen. All rights reserved.
//

import UIKit
import MapKit

class ToiletLocationViewController: UIViewController {

    @IBOutlet weak var toiletMapView: MKMapView!
  
    var stateController:ToiletStateController?
  
  @IBAction func mapViewAction(sender: AnyObject) {
    if sender.selectedIndex == 0
    {toiletMapView.mapType = MKMapType.Satellite}
    else if sender.selectedIndex == 1
    {toiletMapView.mapType = MKMapType.Standard}
    else if sender.selectedIndex == 2
    {toiletMapView.mapType = MKMapType.Hybrid }
    
  }
  
    override func viewDidLoad() {
        super.viewDidLoad()
      
      
        toiletMapView.delegate = self
      
      
     let jsonDownloadController = JSONDownload(urlPath: "http://events.makeable.dk/api/getEvents")

      if let stateController = stateController {
        jsonDownloadController.delegate = stateController
        stateController.delegate = self
    }
}
