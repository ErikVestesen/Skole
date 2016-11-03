//
//  JSONDownload.swift
//  TopGithub
//
//  Created by DMU MAC 01 on 03/11/2016.
//  Copyright © 2016 E. All rights reserved.
//

import Foundation

class JSONDownload {
  var delegate: JSONDownloadDelegate
  
  enum JSONError: String, Error {
    case NoData = "Error: No Data!"
    case ConversionFailed = "Error: Converison from JSON Failed!"
  }
  
  init(urlPath: String, delegate: JSONDownloadDelegate) {
    self.delegate = delegate
    
    if let endPoint = URL(string: urlPath) {
        let request = URLRequest(url: endPoint)
      
      URLSession.shared.dataTask(with: request, completionHandler: {

        (data,response, error) in
        do {
            guard let data = data else {
              throw JSONError.NoData
            }
          let json = JSON(data: data)
          
          DispatchQueue.main.async {
            delegate.finishedDownloading(data: json)
          }
          
        } catch let error as JSONError {
          print(error.rawValue)
        } catch let error {
          print(error.localizedDescription)
        }
        
      
      }).resume()
      
    }
  }

}
