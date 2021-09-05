using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFServiceApp.Model
{
    public interface IHandler
    {
        IHandler SetNext(IHandler handler);

        object Handle(object request);
    }

    abstract class AbstractHandler : IHandler
    {
        private IHandler nextHandler;
        public IHandler SetNext(IHandler handler)
        {
            this.nextHandler = handler;

            return handler;
        }

        public virtual object Handle(object request)
        {
            if (this.nextHandler != null)
            {
                return this.nextHandler.Handle(request);
            }
            else
            {
                return null;
            }
        }        
    }

    class SpaceHandler : AbstractHandler
    { 
        public override object Handle(object request)
        {
            if (!(request as string).Contains(" "))
                return base.Handle(request);

            return false;
        }
    }

    class EmptyHandler : AbstractHandler
    { 
        public override object Handle(object request)
        {
            if ((request as string) != string.Empty)
                return base.Handle(request);

            return false;
        }
    }

    class LowercaseHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if ((request as string).Any(char.IsLower))
                return base.Handle(request);

            return false;
        }
    }

    class UppercaseHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if ((request as string).Any(char.IsUpper))
                return base.Handle(request);

            return false;
        }
    }

    class NumberHandler : AbstractHandler
    {
        public override object Handle(object request)
        {
            if ((request as string).Any(char.IsNumber))
                return base.Handle(request);

            return false;
        }
    }

    class SpecialHandler : AbstractHandler
    {
        private List<char> specials = new List<char>() { '*', '&'};
        public override object Handle(object request)
        {
            if (specials.Any(x => (request as string).Contains(x)))
                return base.Handle(request);

            return false;
        }
    }

    public static class PassChain
    {
        public static bool CheckPass(AbstractHandler handler)
        {

        }
    }
}
