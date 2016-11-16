//
//  ViewController.swift
//  WeatherApp
//
//  Created by Erik Vestesen on 16/11/16.
//  Copyright © 2016 Erik Vestesen. All rights reserved.
//

import UIKit
import MapKit

class ViewController: UIViewController, MKMapViewDelegate, StateControllerDelegate {
    
    @IBOutlet weak var WeatherLocationMapView: MKMapView!
    var stateController: StateController?
    
    func dataIsReady() {
            let weatherLocation = stateController?.weatherLocation
            let pin = MKPointAnnotation()
            pin.coordinate = CLLocationCoordinate2DMake(CLLocation().coordinate.latitude, CLLocation().coordinate.longitude)
            pin.title = (weatherLocation?.weatherDescription)! + (weatherLocation?.weatherMain)!
        WeatherLocationMapView.addAnnotation(pin)

    }
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        WeatherLocationMapView.delegate = self
        
        let locManager = CLLocationManager() // flyt til appDelegate?
        locManager.requestWhenInUseAuthorization()
        var currentLocation = CLLocation()
        
        if( CLLocationManager.authorizationStatus() == CLAuthorizationStatus.authorizedWhenInUse ||
            CLLocationManager.authorizationStatus() == CLAuthorizationStatus.authorizedAlways){
            
            currentLocation = locManager.location!
            _ = JSONDownload(urlPath:"api.openweathermap.org/data/2.5/weather?lat=\(currentLocation.coordinate.latitude)&lon=\(currentLocation.coordinate.longitude)", delegate: stateController!)
            stateController?.delegate = self
        }
        
    }
}

