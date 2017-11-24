import axios from "axios";

export const postURLEncode=(url, data)=>{
    console.log(data);
  return axios({
        method: 'post',
        headers: {
                'Content-type': 'application/x-www-form-urlencoded'
            },
        url,
        data
    })
      .then(res => {
            if(res.status==200)
              return {
                  succsses: true,
                  data: res.data
              }
            else return {
                succsses: false,
                data: res.status + " "+ res.message 
            }
      })
      .catch(error => {
        return {
            succsses: false,
            data: error
        }
      });
}
export const postJSON=(url, data)=>{
    console.log(data);
    return axios({
        method: 'post',
        headers: {
                'Authorization': 'Bearer '+window.localStorage.getItem("app_token")
            },
        url,
        data
    })
    .then(res => {
            if(res.status==200)
            return {
                succsses: true,
                data: res.data
            }
            else return {
                succsses: false,
                data: res.status + " "+ res.message 
            }
    })
    .catch(error => {
        return {
            succsses: false,
            data: error
        }
    });
}
export const getJSON=(url)=>{
    return axios({
        method: 'get',
        headers: {
                'Authorization': 'Bearer '+window.localStorage.getItem("app_token")
            },
        url
    })
    .then(res => {
            if(res.status==200)
            return {
                succsses: true,
                data: res.data
            }
            else return {
                succsses: false,
                error: res.status + " "+ res.message 
            }
    })
    .catch(error => {
        return {
            succsses: false,
            error: error
        }
    });
}