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
    
  @IBOutlet weak var lblHumidity: UILabel!
  @IBOutlet weak var lblTemp: UILabel!
  @IBOutlet weak var lblWeather: UILabel!
    @IBOutlet weak var WeatherLocationMapView: MKMapView!
    var stateController: StateController?
    
    func dataIsReady() {
            let weatherLocation = stateController?.weatherLocation
            let pin = MKPointAnnotation()
            pin.coordinate = CLLocationCoordinate2DMake(56.17013, 10.19544)
            pin.title = (weatherLocation?.weatherDescription)!
        lblTemp.text = weatherLocation?.temp
        lblHumidity.text = weatherLocation?.humidity
        lblWeather.text = weatherLocation?.weatherMain
      
        WeatherLocationMapView.addAnnotation(pin)
    }
    
    override func viewDidLoad() {
        super.viewDidLoad()
        
        WeatherLocationMapView.delegate = self
      
        _ = JSONDownload(urlPath:"http://api.openweathermap.org/data/2.5/weather?lat=56.17013&lon=10.19544&APPID=ffb3eb29318bf8fe6c150d9b9f4b2157", delegate: stateController!)
        stateController?.delegate = self
        
        
    }
}
