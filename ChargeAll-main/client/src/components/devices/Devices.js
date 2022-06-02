import React, { useEffect, useState, useTransition } from 'react'
import ax from '../../ax'
import { Link } from "react-router-dom"
import image1 from "../../assets/images/charge2.png"
import axios from 'axios'
import { useAuth } from '../../context/AuthContext'
const Devices = (props) => {
  const [devices, setDevices] = useState([])
  const [loading, setLoading] = useState(false)
  const [error, setError] = useState(false)
  const { path } = props.match
  const userSite = localStorage.getItem("site")
  const { deviceLoc } = useAuth()
  useEffect(() => {
    (async () => {
      setLoading(true)
      ax.get(`${path}/bysite/${userSite}`).then(res => {
        setDevices(res.data)
      }).catch(err => {
        setError(err)
        console.log(error)
      }).finally(() => setLoading(false))
    })()
  }, [path, error])

  const renderDevices = () => {
    return devices && devices.map((device, i) => {
      const locArea = deviceLoc && deviceLoc.find(x => x.id === device._id)
      return (
        <div key={i} className='d-flex justify-content-between mb-4 border-bottom p-2 rounded align-items-center'>
          <div className='d-flex align-items-center'>
            <div>
              <img src={image1} style={{ width: 80 }} alt='görsel' />
            </div>
            <div className='ms-3 text-capitalize'>
              <Link to={`/device/update/${device._id}`}>
                <label className='pb-2' style={{ fontSize: 21, fontWeight: 500, color: "black" }}>{device.devicename}</label>
              </Link>
              <div>
                <div className='' >
                  <label style={{ width: 130 }}>Site</label>
                  <label>: {device.site}</label>
                </div>
                <div>
                  <label style={{ width: 130 }}>Cihaz id</label>
                  <label>: {device.deviceid}</label>
                </div>
                <div>
                  <label style={{ width: 130 }}>Konum</label>
                  <label>{!locArea ? ": Loading" : ": " + locArea.value.slice(8)}</label>
                </div>
                <div>
                  <label style={{ width: 130 }}>Kullanan Kullanıcı</label>
                  <label>: {device.charginguser ? device.charginguser : "Kullanılmıyor."}</label>
                </div>
                <div>
                  <label style={{ width: 130 }}>Ücret</label>
                  <label>: {device.price}</label>
                </div>
                <div>
                  <label style={{ width: 130 }}>Tip</label>
                  <label>: {device.type}</label>
                </div>

              </div>
            </div>
          </div>
          <div className='d-flex flex-column'>
            <div className={`${device.state == "1" ? "bg-danger" : "bg-success"} text-center mb-4 badge rounded-pill py-2 `}>
              {device.state == "1" ? "Meşgul" : "Müsait"}
            </div>
            <Link to={`/device/${device._id}`} style={{ backgroundColor: "#f3f3f3", color: "black" }} className=' border px-4 py-1 rounded opacity-75 text-decoration-none text-center'>Detaylar</Link>
          </div>
        </div>
      )
    })
  }
  if (loading) return (
    <div className="d-flex justify-content-center">
      <div className="spinner-border" role="status">
        <span className="visually-hidden">Loading...</span>
      </div>
    </div>
  )
  return (
    <div className='container'>
      <div className='text-center fs-3 '>Cihazlar</div>
      {renderDevices()}
    </div>
  )
}

export default Devices