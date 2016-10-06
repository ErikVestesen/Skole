//
//  JSONDownload.swift
//  To-Do
//
//  Created by Kaj Schermer Didriksen on 20/09/2016.
//  Copyright © 2016 Kaj Schermer Didriksen. All rights reserved.
//

import Foundation


class JSONDownload {
    
    var delegate: JSONDownloadDelegate?
    
    enum JSONError: String, ErrorType {
        case NoData = "Error: No Data!"
        case ConvertionFailed = "Error: Conversion from JSON failed"
    }
    
    init(urlPath:String) {
        
        if let endPoint = NSURL(string: urlPath) {
            let request = NSMutableURLRequest(URL: endPoint)
            NSURLSession.sharedSession().dataTaskWithRequest(request) { (data, response, error) in
                
                do {
                    guard let data = data else {
                        throw JSONError.NoData
                    }
                    guard let json = try NSJSONSerialization.JSONObjectWithData(data, options: []) as? [String: AnyObject] else {
                        throw JSONError.ConvertionFailed
                    }
                    
                    dispatch_async(dispatch_get_main_queue()) {
                        if let delegate = self.delegate {
                            delegate.finishedDownloadingJSON(json)
                        }
                    }
                    
                } catch let error as JSONError {
                    print(error.rawValue)
                } catch let error as NSError {
                    print(error.debugDescription)
                }
                
                }.resume()
        }
    }
}