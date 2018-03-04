using Day1Training.APIServices;
using Day1Training.Helpers;
using Day1Training.Model;
using Newtonsoft.Json;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Day1Training.APIServices
{
    public  class ServiceManager : IServiceManager
    {
        #region fields
        ServiceResponse svcResponse;
        #endregion

        #region method

        public ServiceManager()
        {
            svcResponse= new ServiceResponse();
            svcResponse.ErrorObject = new Error();
        }

        /// <summary>
        /// GetData is ageneric method to call restfull service and getting the data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="methodName"></param>
        /// <returns></returns>
        public async Task<ServiceResponse> GetData<T>(string methodName,string AccessToken=null)
        {
            string response = string.Empty;
          
                try
                {
                    string serviceUrl = Helpers.AppConstants.GetSettingsItem("BaseURL");

                    if (string.IsNullOrEmpty(serviceUrl))
                    {   
                        svcResponse.ErrorObject.Message = AppConstants.CantReadSettingfile;
                        svcResponse.Success = false;
                        return svcResponse;
                    }
                    Uri geturi = new Uri(serviceUrl + methodName, UriKind.RelativeOrAbsolute);
                     using (var client = new HttpClient())
                      {
                       if (AccessToken != null)
                       {
                           client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                       }
                    
                       System.Net.Http.HttpResponseMessage getResponse = await client.GetAsync(geturi);
                       response = await getResponse.Content.ReadAsStringAsync();
                       if (getResponse.IsSuccessStatusCode)
                        {
                           svcResponse.ResponseObject = JsonConvert.DeserializeObject<T>(response);
                           svcResponse.Success = true;
                          return svcResponse;
                        }
                    else
                    {
                        try
                        {
                            svcResponse.ErrorObject = JsonConvert.DeserializeObject<Error>(response);

                        }
                        catch (Exception ex)
                        {
                           
                            svcResponse.ErrorObject.Message = ex.Message;
                            svcResponse.Success = false;
                            svcResponse.ErrorObject.Message = AppConstants.UnhandledException;
                           
                        }

                        svcResponse.ResponseObject = null;
                        svcResponse.Success = false;
                        return svcResponse;
                    }
                }
                }
                catch (HttpRequestException ex)
                {
                  
                    svcResponse.ResponseObject = null;
                    svcResponse.ErrorObject.Message = AppConstants.HttpRequestException;
                    svcResponse.ErrorObject.Message +=" "+ ex.Message;
                    svcResponse.Success = false;
                 
                }
                catch (JsonSerializationException ex)
                {
                    if (!string.IsNullOrEmpty(response))
                    {
                  
                   
                    svcResponse.ErrorObject.Message = AppConstants.SerilizationExceptoin;
                    svcResponse.ErrorObject.Message += " " + ex.Message;
                    svcResponse.Success = false;
                    }
                    else
                    {

                    svcResponse.ErrorObject.Message = AppConstants.SerilizationExceptoin;
                    svcResponse.ErrorObject.Message += " " + ex.Message;
                    svcResponse.Success = false;
                    }
              

            }
                catch (Exception ex)
                {

                svcResponse.ErrorObject.Message = AppConstants.UnhandledException;
                svcResponse.ErrorObject.Message += " " + ex.Message;
                
            
                    svcResponse.Success = false;
               
            }
           

            return svcResponse;

        }

        /// <summary>
        /// PostData is ageneric method to authenticate the users 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="methodName"></param>
        /// <param name="postedObject"></param>
        /// <returns></returns>
        public async Task<ServiceResponse> PostData<T>(string methodName, object postedObject)
        {
            string response = string.Empty;
                try
                {
                    string serviceUrl = Helpers.AppConstants.GetSettingsItem("BaseURL");
                    Uri requestUri = new Uri(serviceUrl + methodName, UriKind.RelativeOrAbsolute);
                    string json = "";

                    json = Newtonsoft.Json.JsonConvert.SerializeObject(postedObject);
                    var objClint = new System.Net.Http.HttpClient();

                    FormUrlEncodedContent formContent =new FormUrlEncodedContent((Dictionary<string,string>)postedObject);

                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    System.Net.Http.HttpResponseMessage respon = await objClint.PostAsync(requestUri, formContent);
                    response = await respon.Content.ReadAsStringAsync();

                    if (respon.IsSuccessStatusCode)
                    {
                        svcResponse.ResponseObject = JsonConvert.DeserializeObject<T>(response);
                        svcResponse.Success = true;
                        return svcResponse;
                    }
                    else
                    {
                        try
                        {
                            svcResponse.ErrorObject = JsonConvert.DeserializeObject<Error>(response);   
                        }
                        catch (Exception ex)
                        {
                            svcResponse.Success = false;
                            svcResponse.ErrorObject.Message = AppConstants.UnhandledException;
                            svcResponse.ErrorObject.Message +=" "+ ex.Message;
                        }


                        svcResponse.ResponseObject = null;
                        svcResponse.Success = false;
                        return svcResponse;

                    }

                }
                catch (HttpRequestException ex)
                {
                     svcResponse.ResponseObject = null;
                     svcResponse.ErrorObject.Message = AppConstants.HttpRequestException;
                     svcResponse.ErrorObject.Message += " " + ex.Message;
                     svcResponse.Success = false;
                }
                catch (JsonSerializationException ex)
                {
                    if (!string.IsNullOrEmpty(response))
                    {
                        svcResponse.ErrorObject.Message = AppConstants.SerilizationExceptoin;
                        svcResponse.ErrorObject.Message += " "+ ex.Message;
                        svcResponse.Success = false;
                    }
                    else
                    {
                         svcResponse.ErrorObject.Message = AppConstants.SerilizationExceptoin;
                         svcResponse.ErrorObject.Message += " " + ex.Message;
                         svcResponse.Success = false;
                    }
                 
                }
                catch (Exception ex)
                {
                     svcResponse.ErrorObject.Message = AppConstants.UnhandledException;
                     svcResponse.ErrorObject.Message +=" "+ ex.Message;
                     svcResponse.Success = false;
                }
            return svcResponse;
        }

        #endregion
    }
    
}
