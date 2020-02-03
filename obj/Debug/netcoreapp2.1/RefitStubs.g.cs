﻿// <auto-generated />
using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Refit;

/* ******** Hey You! *********
 *
 * This is a generated file, and gets rewritten every time you build the
 * project. If you want to edit it, you need to edit the mustache template
 * in the Refit package */

#pragma warning disable
namespace Visual_Studio_Settings.RefitInternalGenerated
{
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [AttributeUsage (AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Delegate)]
    sealed class PreserveAttribute : Attribute
    {

        //
        // Fields
        //
        public bool AllMembers;

        public bool Conditional;
    }
}
#pragma warning restore

namespace API_tests
{
    using Visual_Studio_Settings.RefitInternalGenerated;

    /// <inheritdoc />
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.Diagnostics.DebuggerNonUserCode]
    [Preserve]
    [global::System.Reflection.Obfuscation(Exclude=true)]
    partial class AutoGeneratedRoomsPageInterfaceDeleteRoom : RoomsPageInterface.DeleteRoom
    {
        /// <inheritdoc />
        public HttpClient Client { get; protected set; }
        readonly IRequestBuilder requestBuilder;

        /// <inheritdoc />
        public AutoGeneratedRoomsPageInterfaceDeleteRoom(HttpClient client, IRequestBuilder requestBuilder)
        {
            Client = client;
            this.requestBuilder = requestBuilder;
        }

        /// <inheritdoc />
        Task RoomsPageInterface.DeleteRoom.DeleteRoom(int gameId)
        {
            var arguments = new object[] { gameId };
            var func = requestBuilder.BuildRestResultFuncForMethod("DeleteRoom", new Type[] { typeof(int) });
            return (Task)func(Client, arguments);
        }
    }
}

namespace API_tests
{
    using Visual_Studio_Settings.RefitInternalGenerated;

    /// <inheritdoc />
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.Diagnostics.DebuggerNonUserCode]
    [Preserve]
    [global::System.Reflection.Obfuscation(Exclude=true)]
    partial class AutoGeneratedRoomsPageInterfaceNewRoomNameInterface : RoomsPageInterface.NewRoomNameInterface
    {
        /// <inheritdoc />
        public HttpClient Client { get; protected set; }
        readonly IRequestBuilder requestBuilder;

        /// <inheritdoc />
        public AutoGeneratedRoomsPageInterfaceNewRoomNameInterface(HttpClient client, IRequestBuilder requestBuilder)
        {
            Client = client;
            this.requestBuilder = requestBuilder;
        }

        /// <inheritdoc />
        Task<GameInfo> RoomsPageInterface.NewRoomNameInterface.GetRoomInfo(RoomBody name)
        {
            var arguments = new object[] { name };
            var func = requestBuilder.BuildRestResultFuncForMethod("GetRoomInfo", new Type[] { typeof(RoomBody) });
            return (Task<GameInfo>)func(Client, arguments);
        }
    }
}

namespace API_tests
{
    using Visual_Studio_Settings.RefitInternalGenerated;

    /// <inheritdoc />
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.Diagnostics.DebuggerNonUserCode]
    [Preserve]
    [global::System.Reflection.Obfuscation(Exclude=true)]
    partial class AutoGeneratedRoomsPageInterfaceRoomActions : RoomsPageInterface.RoomActions
    {
        /// <inheritdoc />
        public HttpClient Client { get; protected set; }
        readonly IRequestBuilder requestBuilder;

        /// <inheritdoc />
        public AutoGeneratedRoomsPageInterfaceRoomActions(HttpClient client, IRequestBuilder requestBuilder)
        {
            Client = client;
            this.requestBuilder = requestBuilder;
        }

        /// <inheritdoc />
        Task<GameInfo> RoomsPageInterface.RoomActions.GetRoomInfo(RoomBody name, RoomBody cardSetType)
        {
            var arguments = new object[] { name, cardSetType };
            var func = requestBuilder.BuildRestResultFuncForMethod("GetRoomInfo", new Type[] { typeof(RoomBody), typeof(RoomBody) });
            return (Task<GameInfo>)func(Client, arguments);
        }
    }
}

namespace API_tests
{
    using Visual_Studio_Settings.RefitInternalGenerated;

    /// <inheritdoc />
    [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    [global::System.Diagnostics.DebuggerNonUserCode]
    [Preserve]
    [global::System.Reflection.Obfuscation(Exclude=true)]
    partial class AutoGeneratedRoomPageInterfaceStoryActions : RoomPageInterface.StoryActions
    {
        /// <inheritdoc />
        public HttpClient Client { get; protected set; }
        readonly IRequestBuilder requestBuilder;

        /// <inheritdoc />
        public AutoGeneratedRoomPageInterfaceStoryActions(HttpClient client, IRequestBuilder requestBuilder)
        {
            Client = client;
            this.requestBuilder = requestBuilder;
        }

        /// <inheritdoc />
        Task<StoryInfo> RoomPageInterface.StoryActions.GetStory(int gameId, StoryBody name)
        {
            var arguments = new object[] { gameId, name };
            var func = requestBuilder.BuildRestResultFuncForMethod("GetStory", new Type[] { typeof(int), typeof(StoryBody) });
            return (Task<StoryInfo>)func(Client, arguments);
        }
    }
}
