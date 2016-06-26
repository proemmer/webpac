// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Webpac.Client
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Models;

    /// <summary>
    /// Extension methods for WebPacClient.
    /// </summary>
    public static partial class WebPacClientExtensions
    {
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='authorization'>
            /// access token
            /// </param>
            public static IList<string> ApiAbsolutesGet(this IWebPacClient operations, string authorization)
            {
                return Task.Factory.StartNew(s => ((IWebPacClient)s).ApiAbsolutesGetAsync(authorization), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='authorization'>
            /// access token
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<string>> ApiAbsolutesGetAsync(this IWebPacClient operations, string authorization, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiAbsolutesGetWithHttpMessagesAsync(authorization, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='area'>
            /// </param>
            /// <param name='address'>
            /// </param>
            /// <param name='authorization'>
            /// access token
            /// </param>
            public static object ApiAbsolutesByAreaByAddressGet(this IWebPacClient operations, string area, string address, string authorization)
            {
                return Task.Factory.StartNew(s => ((IWebPacClient)s).ApiAbsolutesByAreaByAddressGetAsync(area, address, authorization), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='area'>
            /// </param>
            /// <param name='address'>
            /// </param>
            /// <param name='authorization'>
            /// access token
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> ApiAbsolutesByAreaByAddressGetAsync(this IWebPacClient operations, string area, string address, string authorization, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiAbsolutesByAreaByAddressGetWithHttpMessagesAsync(area, address, authorization, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='area'>
            /// </param>
            /// <param name='address'>
            /// </param>
            /// <param name='authorization'>
            /// access token
            /// </param>
            /// <param name='value'>
            /// </param>
            public static void ApiAbsolutesByAreaByAddressPatch(this IWebPacClient operations, string area, string address, string authorization, object value = default(object))
            {
                Task.Factory.StartNew(s => ((IWebPacClient)s).ApiAbsolutesByAreaByAddressPatchAsync(area, address, authorization, value), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='area'>
            /// </param>
            /// <param name='address'>
            /// </param>
            /// <param name='authorization'>
            /// access token
            /// </param>
            /// <param name='value'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task ApiAbsolutesByAreaByAddressPatchAsync(this IWebPacClient operations, string area, string address, string authorization, object value = default(object), CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.ApiAbsolutesByAreaByAddressPatchWithHttpMessagesAsync(area, address, authorization, value, null, cancellationToken).ConfigureAwait(false);
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='area'>
            /// </param>
            /// <param name='authorization'>
            /// access token
            /// </param>
            /// <param name='addresses'>
            /// </param>
            public static IDictionary<string, object> ApiAbsolutesByAreaGet(this IWebPacClient operations, string area, string authorization, IList<string> addresses = default(IList<string>))
            {
                return Task.Factory.StartNew(s => ((IWebPacClient)s).ApiAbsolutesByAreaGetAsync(area, authorization, addresses), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='area'>
            /// </param>
            /// <param name='authorization'>
            /// access token
            /// </param>
            /// <param name='addresses'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IDictionary<string, object>> ApiAbsolutesByAreaGetAsync(this IWebPacClient operations, string area, string authorization, IList<string> addresses = default(IList<string>), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiAbsolutesByAreaGetWithHttpMessagesAsync(area, authorization, addresses, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='area'>
            /// </param>
            /// <param name='authorization'>
            /// access token
            /// </param>
            /// <param name='value'>
            /// </param>
            public static void ApiAbsolutesByAreaPatch(this IWebPacClient operations, string area, string authorization, IDictionary<string, object> value = default(IDictionary<string, object>))
            {
                Task.Factory.StartNew(s => ((IWebPacClient)s).ApiAbsolutesByAreaPatchAsync(area, authorization, value), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='area'>
            /// </param>
            /// <param name='authorization'>
            /// access token
            /// </param>
            /// <param name='value'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task ApiAbsolutesByAreaPatchAsync(this IWebPacClient operations, string area, string authorization, IDictionary<string, object> value = default(IDictionary<string, object>), CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.ApiAbsolutesByAreaPatchWithHttpMessagesAsync(area, authorization, value, null, cancellationToken).ConfigureAwait(false);
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='authorization'>
            /// access token
            /// </param>
            public static IList<string> ApiSymbolicGet(this IWebPacClient operations, string authorization)
            {
                return Task.Factory.StartNew(s => ((IWebPacClient)s).ApiSymbolicGetAsync(authorization), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='authorization'>
            /// access token
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IList<string>> ApiSymbolicGetAsync(this IWebPacClient operations, string authorization, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiSymbolicGetWithHttpMessagesAsync(authorization, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='mapping'>
            /// </param>
            /// <param name='variable'>
            /// </param>
            /// <param name='authorization'>
            /// access token
            /// </param>
            public static IDictionary<string, object> ApiSymbolicByMappingByVariableGet(this IWebPacClient operations, string mapping, string variable, string authorization)
            {
                return Task.Factory.StartNew(s => ((IWebPacClient)s).ApiSymbolicByMappingByVariableGetAsync(mapping, variable, authorization), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='mapping'>
            /// </param>
            /// <param name='variable'>
            /// </param>
            /// <param name='authorization'>
            /// access token
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IDictionary<string, object>> ApiSymbolicByMappingByVariableGetAsync(this IWebPacClient operations, string mapping, string variable, string authorization, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiSymbolicByMappingByVariableGetWithHttpMessagesAsync(mapping, variable, authorization, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='mapping'>
            /// </param>
            /// <param name='variable'>
            /// </param>
            /// <param name='authorization'>
            /// access token
            /// </param>
            /// <param name='value'>
            /// </param>
            public static void ApiSymbolicByMappingByVariablePatch(this IWebPacClient operations, string mapping, string variable, string authorization, object value = default(object))
            {
                Task.Factory.StartNew(s => ((IWebPacClient)s).ApiSymbolicByMappingByVariablePatchAsync(mapping, variable, authorization, value), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='mapping'>
            /// </param>
            /// <param name='variable'>
            /// </param>
            /// <param name='authorization'>
            /// access token
            /// </param>
            /// <param name='value'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task ApiSymbolicByMappingByVariablePatchAsync(this IWebPacClient operations, string mapping, string variable, string authorization, object value = default(object), CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.ApiSymbolicByMappingByVariablePatchWithHttpMessagesAsync(mapping, variable, authorization, value, null, cancellationToken).ConfigureAwait(false);
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='mapping'>
            /// </param>
            /// <param name='authorization'>
            /// access token
            /// </param>
            /// <param name='variables'>
            /// </param>
            public static IDictionary<string, object> ApiSymbolicByMappingGet(this IWebPacClient operations, string mapping, string authorization, IList<string> variables = default(IList<string>))
            {
                return Task.Factory.StartNew(s => ((IWebPacClient)s).ApiSymbolicByMappingGetAsync(mapping, authorization, variables), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='mapping'>
            /// </param>
            /// <param name='authorization'>
            /// access token
            /// </param>
            /// <param name='variables'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<IDictionary<string, object>> ApiSymbolicByMappingGetAsync(this IWebPacClient operations, string mapping, string authorization, IList<string> variables = default(IList<string>), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiSymbolicByMappingGetWithHttpMessagesAsync(mapping, authorization, variables, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='mapping'>
            /// </param>
            /// <param name='authorization'>
            /// access token
            /// </param>
            /// <param name='value'>
            /// </param>
            public static void ApiSymbolicByMappingPut(this IWebPacClient operations, string mapping, string authorization, object value = default(object))
            {
                Task.Factory.StartNew(s => ((IWebPacClient)s).ApiSymbolicByMappingPutAsync(mapping, authorization, value), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='mapping'>
            /// </param>
            /// <param name='authorization'>
            /// access token
            /// </param>
            /// <param name='value'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task ApiSymbolicByMappingPutAsync(this IWebPacClient operations, string mapping, string authorization, object value = default(object), CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.ApiSymbolicByMappingPutWithHttpMessagesAsync(mapping, authorization, value, null, cancellationToken).ConfigureAwait(false);
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='mapping'>
            /// </param>
            /// <param name='authorization'>
            /// access token
            /// </param>
            /// <param name='value'>
            /// </param>
            public static void ApiSymbolicByMappingPatch(this IWebPacClient operations, string mapping, string authorization, IDictionary<string, object> value = default(IDictionary<string, object>))
            {
                Task.Factory.StartNew(s => ((IWebPacClient)s).ApiSymbolicByMappingPatchAsync(mapping, authorization, value), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='mapping'>
            /// </param>
            /// <param name='authorization'>
            /// access token
            /// </param>
            /// <param name='value'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task ApiSymbolicByMappingPatchAsync(this IWebPacClient operations, string mapping, string authorization, IDictionary<string, object> value = default(IDictionary<string, object>), CancellationToken cancellationToken = default(CancellationToken))
            {
                await operations.ApiSymbolicByMappingPatchWithHttpMessagesAsync(mapping, authorization, value, null, cancellationToken).ConfigureAwait(false);
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='req'>
            /// </param>
            public static Authentication ApiTokenPost(this IWebPacClient operations, AuthRequest req = default(AuthRequest))
            {
                return Task.Factory.StartNew(s => ((IWebPacClient)s).ApiTokenPostAsync(req), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='req'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<Authentication> ApiTokenPostAsync(this IWebPacClient operations, AuthRequest req = default(AuthRequest), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.ApiTokenPostWithHttpMessagesAsync(req, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}