
import UIKit

let now = NSDate()

let firstLandPhoneCallDate = NSDate(timeIntervalSinceReferenceDate: -3_938_698_800.0)
let firstCellPhoneCallDate = NSDate(timeIntervalSinceReferenceDate: -875_646_000.0) // negativt før år 2000
let ipadAnnoncementDate = NSDate(timeIntervalSinceReferenceDate: 286_308_000.0) // positivt efter år 2000

let userCalendar = NSCalendar.current

//Komponenter
let firstLandPhoneCallDateComponent = NSDateComponents()
firstLandPhoneCallDateComponent.year = 1876
firstLandPhoneCallDateComponent.month = 3
firstLandPhoneCallDateComponent.day = 10
firstLandPhoneCallDateComponent.timeZone = NSTimeZone(name: "US/Eastern") as TimeZone?

let pacificCalendar = NSCalendar(calendarIdentifier: NSCalendar.Identifier.gregorian)!


let formatter = DateFormatter()
formatter.string(from: firstLandPhoneCallDate as Date)
formatter.dateStyle = .medium // dateStyle = mm-dd-yyyy
formatter.string(from: firstLandPhoneCallDate as Date)
formatter.timeStyle = .short // timeStlye = hh:mm:ss
formatter.string(from: firstLandPhoneCallDate as Date)


formatter.locale = NSLocale(localeIdentifier: "en_US_POSIX") as Locale!
formatter.dateFormat = "y-MM-dd"
formatter.string(from: ipadAnnoncementDate as Date)

formatter.dateFormat = "yyyy-dd-MM hh:mm:ss" // Z = UTC
formatter.date(from: "2016-08-11 00:00:00") //RSS feed, skift xml i url til json