//
//  Toilet.swift
//  Parkinglot
//
//  Created by Erik Vestesen on 29/09/16.
//  Copyright © 2016 Kaj Schermer Didriksen. All rights reserved.
//

import Foundation
import MapKit

struct Toilet {
    let Status: String
    let Adresse: String
    var Location: CLLocation
    var stateController : ToiletStateController?
  var JSONdownload : JSONDownload?
  
    init(Adresse: String, Status:String, location:CLLocation) {
        self.Adresse = Adresse
        self.Status = Status
        self.Location = location
    }
  
  /*
   let pin = MKpointAnnotion()
   
   pin.coordinate = location
   pin.title = "hej"
   
   toiletmapview.addAnnotition(pin)
   toiletmapview. showsUserLocation = true
 
 */
  
  func dataIsReady() {
    var toiletAnnotations = [MKPointAnnotation]()
    for toilet in (stateController?.items)! {
      let pin = MKPointAnnotation()
      pin.coordinate = CLLocationCoordinate2DMake(toilet.Location.coordinate.latitude, toilet.Location.coordinate.longitude)
      pin.title = toilet.Adresse
    }
    //toiletMapView.addAnnotations(toiletAnnotations)
  }

}
