﻿//
//  PureMVC C# Standard
//
//  Copyright(c) 2020 Saad Shams <saad.shams@puremvc.org>
//  Your reuse is governed by the Creative Commons Attribution 3.0 License
//

using PureMVC.Interfaces;
using PureMVC.Patterns.Observer;

namespace PureMVC.Patterns.Mediator
{
    /// <summary>
    /// 基本的<c>IMediator</c>实现。
    /// </summary>
    /// <seealso cref="PureMVC.Core.View"/>
    public class Mediator : Notifier, IMediator
    {
        /// <summary>
        /// <c>Mediator</c>的姓名。
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         通常，<c>Mediator</c>将被编写为服务于一个特定控件或一组控件，因此不需要动态命名。
        ///     </para>
        /// </remarks>
        public static string NAME = "Mediator";

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="mediatorName"></param>
        /// <param name="viewComponent"></param>
        public Mediator(string mediatorName, object viewComponent = null)
        {
            MediatorName = mediatorName ?? NAME;
            ViewComponent = viewComponent;
        }

        /// <summary>
        /// List the <c>INotification</c> names this
        /// <c>Mediator</c> is interested in being notified of.
        /// </summary>
        /// <returns>the list of <c>INotification</c> names</returns>
        public virtual string[] ListNotificationInterests()
        {
            return new string[0];
        }

        /// <summary>
        /// Handle <c>INotification</c>s.
        /// </summary>
        /// <remarks>
        ///     <para>
        ///         Typically this will be handled in a switch statement,
        ///         with one 'case' entry per <c>INotification</c>
        ///         the <c>Mediator</c> is interested in.
        ///     </para>
        /// </remarks>
        /// <param name="notification"></param>
        public virtual void HandleNotification(INotification notification)
        {
        }

        /// <summary>
        /// Called by the View when the Mediator is registered
        /// </summary>
        public virtual void OnRegister()
        {
        }

        /// <summary>
        /// Called by the View when the Mediator is removed
        /// </summary>
        public virtual void OnRemove()
        {
        }

        /// <summary>the mediator name</summary>
        public string MediatorName { get; protected set; }

        /// <summary>The view component</summary>
        public object ViewComponent { get; set; }
    }
}
