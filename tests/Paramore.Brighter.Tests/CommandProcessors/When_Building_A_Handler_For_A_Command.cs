#region Licence
/* The MIT License (MIT)
Copyright © 2014 Ian Cooper <ian_hammond_cooper@yahoo.co.uk>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the “Software”), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
THE SOFTWARE. */

#endregion

using System.Linq;
using FluentAssertions;
using Paramore.Brighter.Tests.CommandProcessors.TestDoubles;
using Xunit;

namespace Paramore.Brighter.Tests.CommandProcessors
{
    public class PipelineForCommandTests
    {
        private readonly PipelineBuilder<MyCommand> _chainBuilder;
        private IHandleRequests<MyCommand> _chainOfResponsibility;
        private readonly RequestContext _requestContext;

        public PipelineForCommandTests()
        {
            var registry = new SubscriberRegistry();
            registry.Register<MyCommand, MyCommandHandler>();
            var handlerFactory = new TestHandlerFactory<MyCommand, MyCommandHandler>(() => new MyCommandHandler());
            _requestContext = new RequestContext();

            _chainBuilder = new PipelineBuilder<MyCommand>(registry, handlerFactory);
            PipelineBuilder<MyCommand>.ClearPipelineCache();
        }

        [Fact]
        public void When_Building_A_Handler_For_A_Command()
        {
            _chainOfResponsibility = _chainBuilder.Build(_requestContext).First();

            _chainOfResponsibility.Context.Should().NotBeNull();
            _chainOfResponsibility.Context.Should().BeSameAs(_requestContext);
        }
    }
}